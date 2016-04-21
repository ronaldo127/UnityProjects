using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	void OnTriggerExit (Collider collider)
	{
		Pin pin = collider.GetComponentInParent<Pin>();
		if (pin) {
			Destroy(pin.gameObject);
		}
	}

}
