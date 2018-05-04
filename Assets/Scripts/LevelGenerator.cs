using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

	public int numberOfObstacles = 10;
	private float minY = 7f;
	private float maxY = 8f;
	private GameObject camera;
	private GameObject[] obstacle;
	private GameObject[] ore;
	private Queue<GameObject> Obstacles;
	private Vector3 spawnPosition;
	private int consecutive1, consecutive2;
	private GameObject temp;
	private float lastObstacleY;
	private int adauga_minereu;
	private int ok = 0;
	private ScoreCalculation scoreBoard;


	private void Awake()
	{
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
		ore = GameObject.FindGameObjectsWithTag ("Ore");
		scoreBoard = FindObjectOfType<ScoreCalculation> ();
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


			if (adauga_minereu == i) 
			{
				Vector3 pos = new Vector3 ();
				pos.x = ore[0].transform.position.x;

				pos.y = spawnPosition.y - Random.Range (3,4);
				Obstacles.Enqueue (Instantiate (ore[0], pos, Quaternion.identity));
				adauga_minereu = -1;
				Debug.Log ("Am adaugat minereu" + pos.x+ " " + pos.y);
			}
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
		adauga_minereu = -1;

		AddPileOfObstacles(numberOfObstacles);

	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (4);
		RemovePileOfObstacles(numberOfObstacles + ok);
	}	

	private void Update()
	{

		if (NeluSanduLeft.index == 0)
			NeluSanduLeft.index = NeluSanduLeft.old_index;
		if (NeluSanduRight.index == 0)
			NeluSanduRight.index = NeluSanduRight.old_index;

		if(camera.transform.position.y > lastObstacleY)
		{
			lastObstacleY = spawnPosition.y;
			adauga_minereu = Random.Range (0, 9);
			AddPileOfObstacles(numberOfObstacles);
			StartCoroutine (Wait ());

			NeluSanduLeft.index += 0.01f;
			NeluSanduRight.index += 0.01f;
			if( NeluSanduLeft.index != 0.01f )
				NeluSanduLeft.old_index = NeluSanduLeft.index;
			if( NeluSanduRight.index != 0.01f)
				NeluSanduRight.old_index = NeluSanduRight.index;
			NeluSanduLeft.lava_index += 0.01f;
			NeluSanduRight.lava_index += 0.01f;
			Debug.Log (NeluSanduLeft.index);
			ok = 1;
		}

		if (NeluSanduLeft.este_distrus == true) 
		{
			StartCoroutine (Destroy_Ore (NeluSanduLeft.coliziune_minereu));
			NeluSanduLeft.este_distrus = false;
			scoreBoard.CalcScore ();
		}
		if (NeluSanduRight.este_distrus == true) 
		{
			StartCoroutine (Destroy_Ore (NeluSanduRight.coliziune_minereu));
			NeluSanduRight.este_distrus = false;
			scoreBoard.CalcScore ();
		}
	}

	IEnumerator Destroy_Ore(Collision2D col)
	{
		yield return new WaitForSeconds (4);
		Debug.Log ("L-am refacut");
		col.gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 1);
	}

}
