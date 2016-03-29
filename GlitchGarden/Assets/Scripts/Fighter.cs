using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Fighter : MonoBehaviour {

	public float damage;
	public bool autoAttack=true;

	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}

	public void Hit(){
		if (currentTarget) {
			Health enemyHealth = currentTarget.GetComponent<Health> ();
			bool isDead = enemyHealth.LoseHP (damage);
			animator.SetBool ("isAttacking", !isDead);
		} else {
			Debug.LogError (name+ " says: no Target found.");
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (autoAttack)
			Attack(collider.gameObject);
	}

	public void Attack (GameObject target)
	{
		if (target.GetComponent<Health>()&&!target.CompareTag(gameObject.tag)){
			currentTarget = target;
			animator.SetBool("isAttacking", true);
		}
	}
}
