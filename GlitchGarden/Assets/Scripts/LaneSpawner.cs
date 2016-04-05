using UnityEngine;
using System.Collections;

public class LaneSpawner : MonoBehaviour {

	[Tooltip("How many seconds until next spawn?")]
	public float spawnTime = 1f;
	[Tooltip("Enemies to be spawned")]
	public GameObject[] enemiesPrefabs;
	[Tooltip("How many seconds until we start?")]
	public float startTime;

	private GameObject attackers;
	private int i=0;

	// Use this for initialization
	void Start () {
		SetupAttackersObject();
		InvokeRepeating("Spawn", startTime, spawnTime);
	}

	private void SetupAttackersObject ()
	{
		attackers = GameObject.Find("Attackers");
		if (attackers == null) attackers = new GameObject("Attackers");
	}

	void Spawn ()
	{
		if (i >= enemiesPrefabs.Length) {
			CancelInvoke("Spawn");
			return;
		}
		GameObject obj = enemiesPrefabs[i++];
		GameObject attacker = Instantiate(obj, this.transform.position, Quaternion.identity) as GameObject;
		attacker.transform.parent = attackers.transform;
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(this.transform.position, Vector3.one);
	}
}
