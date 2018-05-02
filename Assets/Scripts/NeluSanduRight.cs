using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NeluSanduRight : MonoBehaviour
{

	public GameObject a;
	public GameObject camera;
	public Animator anim;
	private Vector3 offset;
	private int hp = 2;
//	private GameObject[] ropeVector;
	public static float index = 0.025f;
	public static Collision2D coliziune_minereu;
	public static bool este_distrus = false;
	void Awake()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		///ropeVector = GameObject.FindGameObjectsWithTag ("Rope");
       
	}

	void Start()
	{
		offset = camera.transform.position - transform.position;
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
        if (Input.GetKeyDown("up"))
            transform.Translate(0, 0.6f, 0);
		if (Input.GetKeyDown ("right"))
		{
			Destroy (gameObject);
			Instantiate (a, new Vector3 ( this.transform.position.x + 1.5f , this.transform.position.y , 0) , Quaternion.identity);
		}
		if( Input.GetKey("space"))
		{
			anim.Play("Attack Right");
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
	

	}

	void OnCollisionStay2D( Collision2D col )
	{
		if (col.gameObject.name.StartsWith("C") == false ) 
		{	
			Debug.Log ("Game over");
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
		}
		else
			if( Input.GetKey("space"))
			{
				hp--;
				if (hp == 0) 
					{
						col.gameObject.transform.localScale = new Vector3 (0, 0, 0);
						hp = 2;
						este_distrus = true;
						coliziune_minereu = col;
					}
			}
				
	}

	IEnumerator Wait()
	{
		
		yield return new WaitForSeconds (0.3f);
		index = 0.025f;

	}	
		

}