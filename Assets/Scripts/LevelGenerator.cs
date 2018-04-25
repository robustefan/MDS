using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject[] obstacle;
	public int numberOfObstacles = 200;
	public float levelWidth = 3f;
	private float minY = 6f;
	private float maxY = 7f;

	// Use this for initialization
	void Start () {

		obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
	

		Vector3 spawnPosition = new Vector3 ();
		spawnPosition.y = 5f;
		int consecutive1 = 1;
		int consecutive2 = 1;

		for (int i = 0; i < numberOfObstacles; i++)
		{
			spawnPosition.y += Random.Range (minY, maxY);
			int id = Random.Range (1, 10);

			if ( consecutive1 % 4 == 0 )
			{
				consecutive1 = 1;
				id = 6;
			}
			if (consecutive2 % 3 == 0) 
			{
				consecutive2 = 1;
				id = 4;
			}
			if (id <=5)
				{
					spawnPosition.x = obstacle [0].transform.position.x;
					Instantiate (obstacle [0], spawnPosition, Quaternion.identity); 
					consecutive1++;
					consecutive2 = 1;
				} 
			else 
				{
					spawnPosition.x = obstacle [1].transform.position.x;
					Instantiate (obstacle [1], spawnPosition, Quaternion.identity); 
					consecutive2++;
					consecutive1 = 1;
						
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
