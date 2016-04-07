using UnityEngine;
using System.Collections;

public class GraveStone : MonoBehaviour {

	private Animator animator;
	void Start(){
		animator = GetComponent<Animator>();
	}


	void OnTriggerStay2D (Collider2D collider)
	{
		print("Stayed!");
		if (!collider.CompareTag(gameObject.tag)){
			animator.SetTrigger("isAttacked");
		}
	}
}
