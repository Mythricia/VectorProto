using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotator : MonoBehaviour {

	public float xRotationRate = 1f;
	public float yRotationRate = 1f;
	public float zRotationRate = 1f;


	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, zRotationRate * Time.deltaTime);
		transform.Rotate(Vector3.up, yRotationRate * Time.deltaTime);
		transform.Rotate(Vector3.right, xRotationRate * Time.deltaTime);
	}
}
