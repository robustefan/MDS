using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NeluSanduLeft : MonoBehaviour
{

	public GameObject a;
	public GameObject camera;
	private Vector3 offset;
	public Animator anim;
	private GameObject lava;
	public float dif;
	public static float index = 0.025f;
	public static float old_index = 0.025f;
	public static float lava_index = 0.01f;
	public static int hp = 3;
	public static int default_hp = 3;
	public static Collision2D coliziune_minereu;
	public static Collision2D coliziune_booster_potion;
	public static Collision2D coliziune_stea;
	public static bool este_distrus = false;
	public static bool este_cules = false;
	public static float old_lava_index;
	public static bool is_invincible = false;
	public static bool este_culeasa_steaua = false;


	void Awake()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Start()
	{
		offset = camera.transform.position - transform.position;
		anim = GetComponent<Animator> ();
		lava = GameObject.FindGameObjectWithTag ("Lava");
		dif = transform.position.y - lava.transform.position.y ;
	}

	void Update()
	{
		if (Input.GetKeyDown ("up") && PauseCanvas.GameIsPaused == false ) 
		{
			if (camera.transform.position.y - lava.transform.position.y < 16.5f )
				lava.transform.Translate (0, -20 * lava_index, 0);


		}

		if (Input.GetKeyDown ("left") && PauseCanvas.GameIsPaused == false )
		{
			Destroy (gameObject);
			Instantiate (a, new Vector3 ( this.transform.position.x - 1.5f , this.transform.position.y , 0) , Quaternion.identity);
		}
		if( Input.GetKeyDown("space") && PauseCanvas.GameIsPaused == false )
		{
			anim.Play("Attack Left");
			index = 0;
			StartCoroutine (Wait ());
		}
	}

	void LateUpdate()
	{
		if(PauseCanvas.GameIsPaused == false )
		{
			camera.transform.position = transform.position + offset;
			camera.transform.Translate (0, index, 0);
			transform.Translate(0, index, 0);
		}

		if( PauseCanvas.GameIsPaused == false )
			lava.transform.Translate (0, lava_index, 0);


	}

	void OnCollisionStay2D( Collision2D col )
	{
		if (col.gameObject.name.Contains ("Potion") == true) 
		{
			coliziune_booster_potion = col;
			old_lava_index = lava_index;
			NeluSanduRight.old_lava_index = NeluSanduRight.lava_index;
			lava_index = 0.01f;
			NeluSanduRight.lava_index = 0.01f;
			col.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			este_cules = true;
		}
		else
			if (col.gameObject.name.Contains ("Star") == true) 
			{
				is_invincible = true;
				NeluSanduLeft.is_invincible = true;
				este_culeasa_steaua = true;
				coliziune_stea = col;
				col.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			}
			else

				if (col.gameObject.name.StartsWith ("C") == false)
				{	
					if ( is_invincible == false && NeluSanduRight.is_invincible == false ) 
					{
						Debug.Log ("Game over");
						index = 0.025f;
						lava_index = 0.01f;
						hp = 3;
						default_hp = 3;
						NeluSanduRight.index = index;
						NeluSanduRight.lava_index = lava_index;
						NeluSanduRight.hp = hp;
						old_index = index;
						SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
					}
				} 
				else 
					if( Input.GetKeyDown("space") && PauseCanvas.GameIsPaused == false )
					{
						hp--;
						if (hp == 0) 
						{
							col.gameObject.transform.localScale = new Vector3 (0, 0, 0);
							hp = default_hp;
							este_distrus = true;
							coliziune_minereu = col;
						}
					}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (0.3f);
		index = old_index;
	}

}