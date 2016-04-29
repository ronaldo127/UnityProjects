using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public LevelManager levelManager;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale=1;
			levelManager.LoadLevel ("01a Start");
		}
	}
}
