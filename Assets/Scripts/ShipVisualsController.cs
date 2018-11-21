using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipVisualsController : MonoBehaviour {

	private float emissionRate;
	public GameObject enginePlume;

	// Use this for initialization
	void Start () {
		enginePlume.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		float mainThruster = Input.GetAxisRaw("Vertical");
		// float strafeThruster = Input.GetAxisRaw("Strafe");
		// float rotateThruster = Input.GetAxisRaw("Rotation");

		if (mainThruster > 0)
		{
			enginePlume.SetActive(true);
		}
		else if (mainThruster == 0)
		{
			enginePlume.SetActive(false);
		}
	}
}
