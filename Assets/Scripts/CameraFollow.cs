using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject[] player;
	private Vector3 offset;

	void Awake()
	{
		player = GameObject.FindGameObjectsWithTag("Player");
	}

	void Start()
	{
		offset = transform.position - player[0].transform.position;
	}
	
	void lateUpdate () 
	{
		if(player[0])
			transform.position = player[0].transform.position + offset;
		
		player = GameObject.FindGameObjectsWithTag("Player");

	}
}
