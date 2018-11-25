using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vec3 = UnityEngine.Vector3;


public class ShipController : MonoBehaviour {

	public float enginePower = 3500;
	public float turnRate = 300;

	public float strafeFactor = 0.5f;
	private Vector3 vel;
	private float rotation;
	private Rigidbody body;

	public vec3 inertiaTensor;

	public bool isThrusting { get; private set; }

	public Transform[] thrustPoints;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		vel.Set(0, 0, 0);
		rotation = 0;

		isThrusting = false;

		body.inertiaTensor = inertiaTensor;
	}

	// Update is called once per frame
	void Update () {
		vel.y = 0;

		vel.z = Input.GetAxisRaw("Thrust");
		vel.x = Input.GetAxisRaw("Strafe");
		rotation = Input.GetAxisRaw("Rotate");

		vel.Normalize();

		if (vel.z > 0) isThrusting = true;
		else isThrusting = false;


		// FIXME: This is an ugly hack, please kill it with fire
		if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}

	void FixedUpdate() {
		float force	= enginePower * Time.deltaTime; // vel * enginePower * Time.deltaTime;
		float torque	= rotation * turnRate * Time.deltaTime;
		/*
		body.AddRelativeForce(force);
		body.AddRelativeTorque(0, torque, 0);
		*/

		foreach (Transform tp in thrustPoints)
		{
			body.AddForceAtPosition((body.transform.forward * vel.z * force) / thrustPoints.Length, tp.position);
		}

		body.AddRelativeForce(vel.x * force, 0, 0);
		body.AddRelativeTorque(0, torque, 0);
	}
}