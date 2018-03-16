using UnityEngine;

public class NeluSanduLeft : MonoBehaviour
{

	public GameObject a;


	void Update()
	{
		if (Input.GetKeyDown ("up"))
			transform.Translate (0, 0.6f, 0);
		if (Input.GetKeyDown ("down"))
			transform.Translate (0, -0.6f, 0);
		if (Input.GetKeyDown ("left"))
		{
			Destroy (gameObject);
			Instantiate (a, new Vector3 ( this.transform.position.x - 0.8f , this.transform.position.y , 0) , Quaternion.identity);
		}

	}

}