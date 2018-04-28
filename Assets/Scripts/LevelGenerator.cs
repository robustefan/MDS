using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public int numberOfObstacles = 20;
    public float levelWidth = 3f;
    private float minY = 6f;
    private float maxY = 7f;

    public GameObject camera;
    public GameObject[] obstacle;
    private Queue<GameObject> Obstacles;
    private Vector3 spawnPosition;
    private int consecutive1, consecutive2;
    private GameObject temp;
    private float lastObstacleY;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    void AddObstacle(int id)
    {
        if (id == 0)
        {
            spawnPosition.x = obstacle[0].transform.position.x;
            Obstacles.Enqueue(Instantiate(obstacle[0], spawnPosition, Quaternion.identity));
            consecutive1++;
            consecutive2 = 1;
        }
        else
        {
            spawnPosition.x = obstacle[1].transform.position.x;
            Obstacles.Enqueue(Instantiate(obstacle[1], spawnPosition, Quaternion.identity));
            consecutive2++;
            consecutive1 = 1;
        }

    }
    void AddPileOfObstacles(int Counter)
    {
        consecutive1 = 1;
        consecutive2 = 1;

        for (int i = 0; i < Counter; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            int id = Random.Range(0, 9) / 5;

            if (consecutive1 % 3 == 0)
            {
                consecutive1 = 1;
                id = 1;
            }
            if (consecutive2 % 3 == 0)
            {
                consecutive2 = 1;
                id = 0;
            }
            AddObstacle(id);
        }
        lastObstacleY = spawnPosition.y;
    }

    void RemoveObstacle()
    {
        temp = (GameObject)Obstacles.Dequeue();
        GameObject.Destroy(temp);
    }
    void RemovePileOfObstacles(int Counter)
    {
        for (int i = 0; i < Counter; i++)
            RemoveObstacle();
    }

    void Start()
    {
        Obstacles = new Queue<GameObject>();
        spawnPosition.y = 5f;

        AddPileOfObstacles(numberOfObstacles / 2);
        lastObstacleY = spawnPosition.y;
        AddPileOfObstacles(numberOfObstacles / 2);
    }

    private void Update()
    {
        if(camera.transform.position.y > lastObstacleY)
        {
            lastObstacleY = spawnPosition.y;
            AddPileOfObstacles(numberOfObstacles / 2);
            RemovePileOfObstacles(numberOfObstacles / 2);
			NeluSanduLeft.index += 0.01f;
			NeluSanduRight.index += 0.01f;
        }
    }

}
