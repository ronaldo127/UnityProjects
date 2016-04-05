using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Health health = collider.GetComponent<Health> ();

		if (health && !collider.CompareTag(gameObject.tag)){
			health.LoseHP (damage);
			Destroy (this.gameObject);
		}
	}
}
