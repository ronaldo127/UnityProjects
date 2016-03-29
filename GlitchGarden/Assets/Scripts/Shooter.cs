using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;

	private Transform spawn;
	private GameObject projectiles;

	// Use this for initialization
	void Start () {
		foreach (Transform child in transform){
			if(child.gameObject.tag == "Spawn"){
				spawn = child;
				break;
			}
		}

		projectiles = GameObject.Find("Projectiles");
		if (projectiles==null){
			projectiles = new GameObject("Projectiles");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShootProjectile(){
		if (projectile) {
			Vector3 spawnPos = transform.position;
			if (spawn) spawnPos = spawn.position;
			GameObject instance = Instantiate (projectile, spawnPos, Quaternion.identity) as GameObject;
			instance.transform.parent = projectiles.transform;
		} else {
			Debug.LogError ("No projectile found, so should not shoot");
		}
	}
}
