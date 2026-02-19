using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour {

	private AudioSource portalSound;
	private AudioSource errorSound;


	public GameObject orangePortal;
	public GameObject bluePortal;
	public GameObject gunTip;

	public static bool hasUsedPortal1 = false;
	public static bool hasUsedPortal2 = false;

	void Start () {
		portalSound = GetComponents<AudioSource>()[0];
		errorSound = GetComponents<AudioSource>()[1];
	}
	
	void Update () {

		if (Input.GetButtonDown("Fire1")) {
			hasUsedPortal1 = true;
			FirePortal("orange");
		} else if (Input.GetButtonDown("Fire2")) {
			hasUsedPortal2 = true;
			FirePortal("blue");
		}
	}

	void FirePortal(string type) {

		RaycastHit hit;

		if (Physics.Raycast(gunTip.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
			portalSound.Play();
			
			GameObject portal = type == "orange" ? orangePortal : bluePortal;

		
			portal.transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
		} else {
			errorSound.Play();
		}
	}
}
