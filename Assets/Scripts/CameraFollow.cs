using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	
	void lateUpdate () 
	{
		transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;

	}
}
