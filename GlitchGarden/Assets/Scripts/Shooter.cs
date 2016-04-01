using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;

	private Transform spawnProjectiles;
	private GameObject projectiles;

	private Animator animator;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform){
			if(child.gameObject.tag == "SpawnProjectiles"){
				spawnProjectiles = child;
				break;
			}
		}

		SetupProjectilesObject();

		animator = GetComponent<Animator>();
	}

	private void SetupProjectilesObject ()
	{
		projectiles = GameObject.Find("Projectiles");
		if (projectiles==null){
			projectiles = new GameObject("Projectiles");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (IsAttackerInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	private bool IsAttackerInLane ()
	{
		GameObject attackers = GameObject.Find ("Attackers");

		if (!attackers) return false;
		Vector3 thisPos = this.transform.position;

		foreach (Transform attackerChild in  attackers.transform) {
			Vector3 attackerPos = attackerChild.position;
			if (attackerPos.y==thisPos.y && attackerPos.x>thisPos.x){
				return true;
			}
		}
		return false;
	}

	public void ShootProjectile(){
		if (projectile) {
			Vector3 spawnPos = transform.position;
			if (spawnProjectiles) spawnPos = spawnProjectiles.position;
			GameObject instance = Instantiate (projectile, spawnPos, Quaternion.identity) as GameObject;
			instance.transform.parent = projectiles.transform;
		} else {
			Debug.LogError ("No projectile found, so should not shoot");
		}
	}
}
