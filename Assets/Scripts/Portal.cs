using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Portal : MonoBehaviour {

	public GameObject linkedPortal;

	private bool portalActive = true;

	
	void OnTriggerEnter(Collider other) {

		if (portalActive & PortalGun.hasUsedPortal1 & PortalGun.hasUsedPortal2) {

			linkedPortal.GetComponent<Portal>().Toggle();

			Toggle();

			float xRot = other.transform.rotation.x;
			float zRot = other.transform.rotation.z;

			other.transform.SetPositionAndRotation(linkedPortal.transform.position, 
				Quaternion.identity);
			other.transform.rotation = linkedPortal.transform.parent.transform.rotation;

			float yRot = other.transform.eulerAngles.y;

			other.transform.eulerAngles = new Vector3(xRot, yRot, zRot);

			other.GetComponent<FirstPersonController>().MouseReset();
		}
	}
	

	void OnTriggerExit(Collider other) {


		Toggle();
	}

	public void Toggle() {

		portalActive = !portalActive;
	}
}
