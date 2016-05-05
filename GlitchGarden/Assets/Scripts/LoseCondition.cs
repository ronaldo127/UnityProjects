using UnityEngine;
using System.Collections;

public class LoseCondition : Shredder {

	[Tooltip("Configure here the amount of enemies that will make the player lose.")]
	public int enemiesCanPass;
	public bool canLose = true;

	public LevelManager levelManager;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Override Shredder method
	new public void OnTriggerEnter2D (Collider2D collider)
	{
		if (canLose) {
			if (collider.GetComponent<Attacker> ())
				enemiesCanPass--;
			if (enemiesCanPass <= 0) {
				Lose();
			}
		}
		base.OnTriggerEnter2D(collider);
	}

	private void Lose(){
		PlayerPrefsManager.SetLostLevel(levelManager.GetCurrentLevel());
		levelManager.LoadLoseScene();
	}
}
