using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Defender : MonoBehaviour {

	public int cost;

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
