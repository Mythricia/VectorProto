using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PointAt : MonoBehaviour {

	public Transform playerTransform;
#if UNITY_EDITOR
	// Use this for initialization
	void Start () {
if(!Application.isPlaying)	this.transform.LookAt(playerTransform);
	}

	// Update is called once per frame
	void Update () {
if(!Application.isPlaying) this.transform.LookAt(playerTransform);
	}
#endif
}
