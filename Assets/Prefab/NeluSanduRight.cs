using UnityEngine;

public class NeluSanduRight : MonoBehaviour
{

	public GameObject a;
    //public GameObject[] camera;
    public new GameObject[] camera;
   // private GameObject rope;
    private GameObject BigRope;
	private Vector3 offset;
    private float RopeDistance = 3.84f;
    public float BigRopeDistance = 17.7f;
    public int BigRopeCounter = 0;
    public int RopeInstatiate = 30;
	void Awake()
	{
		camera = GameObject.FindGameObjectsWithTag ("MainCamera");
        //rope = GameObject.FindGameObjectWithTag("Rope");
        BigRope = GameObject.FindGameObjectWithTag("BigRope");
       
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
            ++BigRopeCounter;
            if(BigRopeCounter%30 == 0)
            BigRope = Instantiate(BigRope, new Vector3(BigRope.transform.position.x, BigRope.transform.position.y + BigRopeDistance, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown("down"))
        {
            transform.Translate(0, -0.6f, 0);
            --BigRopeCounter;
            if(BigRopeCounter%30 == 0)
                BigRope = Instantiate(BigRope, new Vector3(BigRope.transform.position.x, BigRope.transform.position.y + BigRopeDistance, 0), Quaternion.identity);


        }
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