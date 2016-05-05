using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	public int scenesBeforeLevels = 2;

	void Start () {
        if (autoLoadNextLevelAfter>0)
		    Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
	}

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }

    public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoadLoseScene(){
		LoadLevel("03b Lose");
	}

	public int GetCurrentLevel(){
		Scene scene = SceneManager.GetActiveScene();
		if (scene.name.Contains("Level"))
			return SceneManager.GetActiveScene().buildIndex - scenesBeforeLevels+1;
		else
			return -1;
	}

	public void LoadLostLevel ()
	{
		int levelToLoad = scenesBeforeLevels-1+PlayerPrefsManager.GetLostLevel();
		SceneManager.LoadScene(levelToLoad);
	}
}
