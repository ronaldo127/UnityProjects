using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		SceneManager.LoadScene(name);
	}

	public void StartGame ()
	{
		Brick.ResetBrickCount();
		LoadLevel("Level01");
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		Brick.ResetBrickCount();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void BrickDestroyed(){
		if(Brick.BrickCount()<=0){
			LoadNextLevel();
		}
	}
}
