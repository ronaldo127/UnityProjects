using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

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
}
