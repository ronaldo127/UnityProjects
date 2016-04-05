using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour {

	public int secondsToSurvive = 100;
	public AudioClip winSound;
	public LevelManager levelManager;

	private MusicPlayer musicPlayer;
	private float currentTime = 0.0f;
	private Slider slider;
	private bool hasWon;
	private GameObject winText;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
		if (!musicPlayer)
			Debug.LogWarning ("There is no MusicPlayer in Scene, so load SplashScreen first.");
		FindWinLabel ();
		hasWon = false;
	}

	void FindWinLabel ()
	{
		winText = GameObject.Find ("Win") as GameObject;
		if (!winText)
			Debug.LogWarning ("Insert the Win label named [Win]");
		else
			winText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime += Time.deltaTime;
		slider.value = Mathf.Clamp(currentTime / secondsToSurvive, 0.0f, 1.0f);
		if (slider.value==1.0f&&!hasWon) {
			Win();
		}
	}
	private void Win ()
	{
		DestroyActors();
		hasWon=true;
		if (winText) winText.SetActive(true);
		if (musicPlayer) musicPlayer.PlayAudio(winSound);
		Invoke("LoadNextLevel", winSound.length);
	}

	private void DestroyActors ()
	{
		GameObject[] attackers = GameObject.FindGameObjectsWithTag ("Attacker");
		GameObject[] defenders = GameObject.FindGameObjectsWithTag ("Defender");
		foreach (GameObject aux in attackers) {
			Destroy(aux);
		}
		foreach (GameObject aux in defenders) {
			Destroy(aux);
		}
	}

	private void LoadNextLevel ()
	{
		levelManager.LoadNextLevel();
	}
}
