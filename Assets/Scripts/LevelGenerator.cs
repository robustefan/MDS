using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

	public int numberOfObstacles = 10;
	private float minY = 8.5f;
	private float maxY = 11f;
	private GameObject camera;
	private GameObject player;
	private GameObject[] obstacle;
	private GameObject[] ore;
	private GameObject[] boosterStar;
	private GameObject[] boosterPotion;
	private Queue<GameObject> Obstacles;
	private Vector3 spawnPosition;
	private int consecutive1, consecutive2;
	private GameObject temp;
	private float lastObstacleY;
	private int adauga_minereu;
	private int ok = 0;
	private ScoreCalculation scoreBoard;
	private BoxCollider2D boxCol;
	public static bool upgrade_weap = false;
	private Vector3 offset;


	private void Awake()
	{
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
		ore = GameObject.FindGameObjectsWithTag ("Ore");
		boosterStar = GameObject.FindGameObjectsWithTag ("BoosterStar");
		boosterPotion = GameObject.FindGameObjectsWithTag ("BoosterPotion");
		scoreBoard = FindObjectOfType<ScoreCalculation> ();
		offset = camera.transform.position - GameObject.FindGameObjectWithTag ("Player").transform.position;
		Debug.Log (offset);
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

		int adauga_potiune = Random.Range (1, 10);
		int adauga_stea = Random.Range (1, 10);
		int alegere = Random.Range (1, 3);

		if( alegere == 1)
			if (adauga_potiune % 3 == 0) 
			{
				Vector3 pos = new Vector3 ();
				int r = Random.Range (0, 2);
				pos.x = boosterPotion [r].transform.position.x;
				pos.y = spawnPosition.y - Random.Range (4, 6);
				Obstacles.Enqueue (Instantiate (boosterPotion [r], pos, Quaternion.identity));
				ok++;
			}
		else
			if  (adauga_stea % 3 == 0) 
			{
				Vector3 pos = new Vector3 ();
				int r = Random.Range (0, 2);
				pos.x = boosterStar [r].transform.position.x;
				pos.y = spawnPosition.y - Random.Range (4, 6);
				Obstacles.Enqueue (Instantiate (boosterStar [r], pos, Quaternion.identity));
				ok++;
			}

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
				int index_minereu = Random.Range (0, 7);
				Vector3 pos = new Vector3 ();
				pos.x = ore[index_minereu].transform.position.x;

				pos.y = spawnPosition.y - Random.Range (4,6);
				Obstacles.Enqueue (Instantiate (ore[index_minereu], pos, Quaternion.identity));
				adauga_minereu = -1;
				ok++;
			}
		}
		lastObstacleY = spawnPosition.y;
			
		if ((ScoreCalculation.number + 1) % 6 == 0 && upgrade_weap == false) 			// upgrade-ul armei la multiplii de 5
		{	
			if (NeluSanduLeft.default_hp != 0) 
			{
				upgrade_weap = true;
				NeluSanduLeft.default_hp--;
			}
			if (NeluSanduRight.default_hp != 0) 
			{
				NeluSanduRight.default_hp--;
				upgrade_weap = true;
			}
		}
			
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
		AddPileOfObstacles(numberOfObstacles);

	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (20);
		RemovePileOfObstacles(numberOfObstacles + ok);
		ok = 0;
	}	

	private void Update()
	{

		if (NeluSanduLeft.index == 0)
			StartCoroutine (ReloadSpeed ());
		if( NeluSanduRight.index == 0 )
			StartCoroutine (ReloadSpeed ());
		
		if(camera.transform.position.y > lastObstacleY - 10f)
		{
			lastObstacleY = spawnPosition.y;
			adauga_minereu = Random.Range (0, numberOfObstacles );
			AddPileOfObstacles(numberOfObstacles);
			StartCoroutine (Wait ());

			NeluSanduLeft.index += 0.001f;
			NeluSanduRight.index += 0.001f;
			if( NeluSanduLeft.index != 0.001f )
				NeluSanduLeft.old_index = NeluSanduLeft.index;
			if( NeluSanduRight.index != 0.001f)
				NeluSanduRight.old_index = NeluSanduRight.index;
			NeluSanduLeft.lava_index += 0.001f;
			NeluSanduRight.lava_index += 0.001f;
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

		if (NeluSanduLeft.este_cules == true ) 
		{
			StartCoroutine (LavaStop (NeluSanduLeft.coliziune_booster_potion));
			NeluSanduLeft.este_cules = false;
		}

		if( NeluSanduRight.este_cules == true )
		{
			StartCoroutine (LavaStop (NeluSanduRight.coliziune_booster_potion));
			NeluSanduRight.este_cules = false;
		}

		if( NeluSanduLeft.este_culeasa_steaua == true )
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			boxCol = player.GetComponent<BoxCollider2D>();
			boxCol.isTrigger = true;
			StartCoroutine (Invincible (NeluSanduLeft.coliziune_stea));
		}

		if (NeluSanduRight.este_culeasa_steaua == true) 
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			boxCol = player.GetComponent<BoxCollider2D>();
			boxCol.isTrigger = true;
			StartCoroutine (Invincible (NeluSanduRight.coliziune_stea));
		}
			

		if (Input.GetKeyDown ("up"))
		{
			camera.transform.Translate (0, -0.6f, 0);
			GameObject.FindGameObjectWithTag("Player").transform.Translate (0, 0.6f, 0);
		}

		if (camera.transform.position.y - GameObject.FindGameObjectWithTag ("Player").transform.position.y < offset.y)
			camera.transform.Translate (0, GameObject.FindGameObjectWithTag ("Player").transform.position.y - camera.transform.position.y + offset.y , 0);

	}

	IEnumerator Destroy_Ore(Collision2D col)
	{
		yield return new WaitForSeconds (4);
		col.gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 1);
	}

	IEnumerator LavaStop(Collision2D col)
	{
		yield return new WaitForSeconds (4);
		NeluSanduRight.lava_index = NeluSanduRight.old_lava_index;
		NeluSanduLeft.lava_index = NeluSanduLeft.old_lava_index;
		col.gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 1);
	}

	IEnumerator Invincible(Collision2D col)
	{
		yield return new WaitForSeconds (4);
		NeluSanduLeft.is_invincible = false;
		NeluSanduRight.is_invincible = false;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<BoxCollider2D> ().isTrigger = false;
		NeluSanduLeft.este_culeasa_steaua = false;
		NeluSanduRight.este_culeasa_steaua = false;
	}

	IEnumerator ReloadSpeed()
	{
		yield return new WaitForSeconds (0.3f);
		NeluSanduLeft.index = NeluSanduLeft.old_index;
		NeluSanduRight.index = NeluSanduRight.old_index;
	}

}
