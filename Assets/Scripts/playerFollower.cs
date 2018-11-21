using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour {

	public GameObject player;
	public float homingTime = 0.3f; // Time it takes for the camera to home onto the player
	private bool validPlayer = false;
	private Transform camTransform;
	private Transform playerTransform;

	private float camStartHeight;

	private Vector3 newPos;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		camTransform = this.GetComponent<Transform>();
		camStartHeight = camTransform.position.y;

		if (player.tag == "Player")
		{
			validPlayer = true;
			playerTransform = player.GetComponent<Transform>();
			newPos = new Vector3(playerTransform.position.x, camStartHeight, playerTransform.position.z);
		}
	}

	// Update is called once per frame
	void Update () {
		if (validPlayer)
		{
			newPos = new Vector3(playerTransform.position.x, camStartHeight, playerTransform.position.z);
			camTransform.position = Vector3.SmoothDamp(camTransform.position, newPos, ref velocity, homingTime);
		}
	}
}
