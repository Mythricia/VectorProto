using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public float enginePower = 3500;
	public float turnRate = 300;

	public float strafeFactor = 0.5f;
	private Vector3 vel;
	private float rotation;
	private Rigidbody body;

	public bool isThrusting { get; private set; }

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		vel.Set(0, 0, 0);
		rotation = 0;

		isThrusting = false;
	}

	// Update is called once per frame
	void Update () {
		vel.y = 0;
		vel.z = Input.GetAxisRaw("Vertical");
		vel.x = Input.GetAxisRaw("Strafe");
		rotation = Input.GetAxisRaw("Rotation");
		vel.Normalize();

		if (vel.z > 0) isThrusting = true;
		else isThrusting = false;
	}

	void FixedUpdate() {
		// this.transform.Translate(vel * Time.deltaTime * playerSpeed, Space.World);
		body.AddRelativeForce(vel * enginePower * Time.deltaTime);
		body.AddRelativeTorque(0, rotation * turnRate * Time.deltaTime, 0);
	}
}
