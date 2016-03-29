using UnityEngine;
using System.Collections;

public class GraveStone : MonoBehaviour {

	private Animator animator;
	void Start(){
		animator = GetComponent<Animator>();
	}


	void OnTriggerEnter2D (Collider2D collider)
	{
		if (!collider.CompareTag(gameObject.tag)){
			animator.SetBool("isAttacked", true);
		}
	}
	void OnTriggerExit2D (Collider2D collider)
	{
		if (!collider.CompareTag(gameObject.tag)){
			animator.SetBool("isAttacked", false);
		}
	}
}
