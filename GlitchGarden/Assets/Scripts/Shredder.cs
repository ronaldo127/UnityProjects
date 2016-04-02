using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D collider){
		Destroy (collider.gameObject);
	}
}
