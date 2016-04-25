using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool shouldRespawn = false;

	private GameObject spawnsHolder;

	// Use this for initialization
	void Start () {
		this.spawnsHolder = GameObject.Find("PlayerSpawnPoints");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (shouldRespawn) {
			this.ReSapawn();
			shouldRespawn = false;
		}
	}


	public void ReSapawn ()
	{
		int spawns = spawnsHolder.transform.childCount;
		Transform spawn = this.spawnsHolder.transform.GetChild(Random.Range(0,spawns));
		this.transform.position = spawn.position;
	}
}
