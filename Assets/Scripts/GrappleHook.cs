using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour {

	ShipController attachedPlayer;

	// Update is called once per frame
	void Update () {

	}


	public void AttachPlayer(ShipController player)
	{
		attachedPlayer = player;
		print("GrappleHook:: I'm attached to player '" + player.gameObject.name + "'");
	}

	void OnDestroy()
	{
		print("GrappleHook:: Destructing...");
	}

	void OnTriggerEnter(Collider other)
	{
		print("GrappleHook:: Hit draggable object: " + other.gameObject.name);
		attachedPlayer.HitDraggable(other.gameObject);
	}
}
