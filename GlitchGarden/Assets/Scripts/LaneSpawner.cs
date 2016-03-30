using UnityEngine;
using System.Collections;

public class LaneSpawner : MonoBehaviour {

	[Tooltip("How many seconds until next spawn?")]
	public float spawnTime;
	[Tooltip("Enemies to be spawned")]
	public GameObject[] enemies;
	[Tooltip("How many seconds until we start?")]
	public float startTime;

	private GameObject attackers;
	private int i=0;

	// Use this for initialization
	void Start () {
		attackers = GameObject.Find("Attackers");
		if (attackers == null) attackers = new GameObject("Attackers");
		InvokeRepeating("Spawn", startTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn ()
	{
		if (i >= enemies.Length) {
			Debug.Log("spawning cancelled");
			CancelInvoke("Spawn");
			return;
		}
		Debug.Log("spawning");
		GameObject obj = enemies[i++];
		GameObject attacker = Instantiate(obj, this.transform.position, Quaternion.identity) as GameObject;
		attacker.transform.parent = attackers.transform;
	}
}
