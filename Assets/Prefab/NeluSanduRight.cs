using UnityEngine;

public class NeluSanduRight : MonoBehaviour
{

	public GameObject a;
	public GameObject[] camera;
    private GameObject rope;
	private Vector3 offset;
    private float RopeDistance = 3.84f;
	void Awake()
	{
		camera = GameObject.FindGameObjectsWithTag ("MainCamera");
        rope = GameObject.FindGameObjectWithTag("Rope");
       
	}

	void Start()
	{
		offset = camera [0].transform.position - transform.position;
	}

	void Update()
	{
        if (Input.GetKeyDown("up"))
        {
            transform.Translate(0, 0.6f, 0);
            rope = Instantiate(rope, new Vector3(rope.transform.position.x, rope.transform.position.y + RopeDistance, 0), Quaternion.identity);
        }
		if (Input.GetKeyDown ("down"))
			transform.Translate (0, -0.6f, 0);
		if (Input.GetKeyDown ("right"))
		{
			Destroy (gameObject);
			Instantiate (a, new Vector3 ( this.transform.position.x + 1.5f , this.transform.position.y , 0) , Quaternion.identity);
		}

	}

	void LateUpdate()
	{
		camera[0].transform.position = transform.position + offset;
	}

}