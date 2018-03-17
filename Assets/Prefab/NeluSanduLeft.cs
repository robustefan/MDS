using UnityEngine;

public class NeluSanduLeft : MonoBehaviour
{

	public GameObject a;
	public GameObject[] camera;
	private Vector3 offset;

	void Awake()
	{
		camera = GameObject.FindGameObjectsWithTag ("MainCamera");
	}

	void Start()
	{
		offset = camera [0].transform.position - transform.position;
	}
		
	void Update()
	{
		if (Input.GetKeyDown ("up"))
			transform.Translate (0, 0.6f, 0);
		if (Input.GetKeyDown ("down"))
			transform.Translate (0, -0.6f, 0);
		if (Input.GetKeyDown ("left"))
		{
			Destroy (gameObject);
			Instantiate (a, new Vector3 ( this.transform.position.x - 1.5f , this.transform.position.y , 0) , Quaternion.identity);
		}
	}

	void LateUpdate()
	{
		camera[0].transform.position = transform.position + offset;
	}
		
}