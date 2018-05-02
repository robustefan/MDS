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
	public static float index;
	public static float old_index;
	public static float lava_index;
	private int hp;
	private int default_hp;
	public static Collision2D coliziune_minereu;
	public static bool este_distrus = false;


	void Awake()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	void Start()
	{
		index = 0.025f;
		lava_index = 0.01f;
		hp = 3;
		offset = camera.transform.position - transform.position;
		anim = GetComponent<Animator> ();
		old_index = index;
		lava = GameObject.FindGameObjectWithTag ("Lava");
		dif = transform.position.y - lava.transform.position.y ;
		default_hp = 3;
	}
		
	void Update()
	{
		if (Input.GetKeyDown ("up")) 
		{
			transform.Translate (0, 0.6f, 0);
			if (camera.transform.position.y - lava.transform.position.y < 16.5f )
				lava.transform.Translate (0, -20 * lava_index, 0);
		
		}

		if (Input.GetKeyDown ("left"))
		{
			Destroy (gameObject);
			Instantiate (a, new Vector3 ( this.transform.position.x - 1.5f , this.transform.position.y , 0) , Quaternion.identity);
		}
		if( Input.GetKeyDown("space"))
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

			transform.Translate(0, index, 0);
		}
		index = old_index;
		if( PauseCanvas.GameIsPaused == false )
			lava.transform.Translate (0, lava_index, 0);

		if (ScoreCalculation.number % 5 == 0)
		if( default_hp != 0 )
			default_hp--;

	}
		
	void OnCollisionStay2D( Collision2D col )
	{
		if (col.gameObject.name.StartsWith("C") == false ) 
		{	
			Debug.Log ("Game over");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
		}
		else
			if( Input.GetKeyDown("space"))
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