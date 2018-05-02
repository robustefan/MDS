using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start()
	{
		offset = transform.position - player.transform.position;
	}
	
	void lateUpdate () 
	{
		if(player)
			transform.position = player.transform.position + offset;
		
		player = GameObject.FindGameObjectWithTag("Player");

	}
}
