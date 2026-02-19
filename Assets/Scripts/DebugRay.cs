using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRay : MonoBehaviour {
	
	void Update () {

		Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
	}
}
