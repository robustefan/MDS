using UnityEngine;
using UnityEngine.SceneManagement;

public class NeluSanduRight : MonoBehaviour
{

	public GameObject a;
	public GameObject camera;
	private Vector3 offset;
//	private GameObject[] ropeVector;
	private float index = 0.025f;
	void Awake()
	{
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		///ropeVector = GameObject.FindGameObjectsWithTag ("Rope");
       
	}

	void Start()
	{
		offset = camera.transform.position - transform.position;
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


	}

	void LateUpdate()
	{
        if(PauseCanvas.GameIsPaused == false )
        {
            camera.transform.position = transform.position + offset;

            transform.Translate(0, index, 0);
        }
	

	}

	void OnCollisionEnter2D( Collision2D col )
	{
		Debug.Log ("Game over");
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

}