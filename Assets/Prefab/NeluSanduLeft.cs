using UnityEngine;

public class NeluSanduLeft : MonoBehaviour
{

	public GameObject a;
    private new GameObject[] camera;
    private Vector3 offset;

    public GameObject[] Camera
    {
        get
        {
            return camera;
        }

        set
        {
            camera = value;
        }
    }

    void Awake()
	{
		Camera = GameObject.FindGameObjectsWithTag ("MainCamera");
	}

	void Start()
	{
		offset = Camera [0].transform.position - transform.position;
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
		Camera[0].transform.position = transform.position + offset;
	}
		
}