using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

	public GameObject Background;
	public Queue<GameObject> Backgrounds;
	public GameObject camera;
	private int ColliderCounter = 1;
	private float BackgroundCollider = 17.6f;
	private float BackgroundHeight = 17.6f;
	private GameObject temp;

	public GameObject Rope;
	public Queue<GameObject> Ropes;

	void Awake ()
	{
		Background = GameObject.FindGameObjectWithTag("Background");
		Rope = GameObject.FindGameObjectWithTag("BigRope");
	}
	void AddBackground(int Counter)
	{
		temp = Instantiate(
			Background,
			new Vector3(Background.transform.position.x, Background.transform.position.y + BackgroundHeight * Counter, Background.transform.position.z),
			Background.transform.rotation
		);
		Backgrounds.Enqueue(temp);
	}
	void RemoveBackground()
	{
		temp = (GameObject)Backgrounds.Dequeue();
		GameObject.Destroy(temp);
	}

	void AddRope(int Counter)
	{
		temp = Instantiate(
			Rope,
			new Vector3(Rope.transform.position.x, Rope.transform.position.y + BackgroundHeight * ColliderCounter, Rope.transform.position.z),
			Rope.transform.rotation
		);
		Ropes.Enqueue(temp);
	}
	void RemoveRope()
	{
		temp = (GameObject)Ropes.Dequeue();
		GameObject.Destroy(temp);
	}

	void Start()
	{

		Backgrounds = new Queue<GameObject>();
		Ropes = new Queue<GameObject>();
		for (int i = 0; i < 2; ++i)
		{
			AddBackground(i);
			AddRope(i);
		}
	}

	void UpdateBackground(int Counter)
	{
		AddBackground(Counter);
		RemoveBackground();
	}
	void UpdateRope(int Counter)
	{
		AddRope(Counter);
		RemoveRope();
	}
	void Update()
	{
		if (camera.transform.position.y > BackgroundCollider)
			// Un fel de "collider logic".
			// Cand se ajunge la sfarsitul Backgroundului , se spawneaza un background si franghie mai sus , si se sterg de mai jos.
			// As putea sa pun un collider la propriu la background , dar nu sunt sigur inca  cum functioneaza.
		{
			BackgroundCollider += BackgroundHeight;
			++ColliderCounter;
			UpdateBackground(ColliderCounter);
			UpdateRope(ColliderCounter);
		}
	}
}
