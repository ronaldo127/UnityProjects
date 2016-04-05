using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Attacker))]
public class Fox : MonoBehaviour {
	
	private Fighter fighter;
	private Animator animator;

	void Start () {
		this.fighter = GetComponent<Fighter> ();
		this.animator = GetComponent<Animator> ();
	}


	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<GraveStone> ()) {
			animator.SetTrigger ("jump trigger");
		} else {
			fighter.Attack (collider.gameObject);
		}
	}
}
