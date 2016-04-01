using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Defender : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
