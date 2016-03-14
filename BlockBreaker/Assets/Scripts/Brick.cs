using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] damagedBricks;
	public AudioClip crack;
	public GameObject smoke;

	private static int BREAKABLE_COUNT=0;
	private LevelManager levelManager;
	private int maxHits;
	private int timesHits;
	private SpriteRenderer sr;
	private bool isBreakable;


	// Use this for initialization
	void Start () {
		timesHits=0;
		sr = GetComponent<SpriteRenderer>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		maxHits = damagedBricks.Length+1;
		if (isBreakable=this.tag=="Breakable")
			BREAKABLE_COUNT++;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
		if (isBreakable)
			HandleHits();
	}

	void HandleHits ()
	{
		timesHits++;
		if (timesHits >= maxHits) {
			Instantiate(smoke, this.transform.position, Quaternion.identity);
			Destroy (this.gameObject);
			BREAKABLE_COUNT--;
			levelManager.BrickDestroyed ();
		} else {
			Sprite sprite = damagedBricks [timesHits - 1];
			if (sprite!=null){
				sr.sprite = sprite;
			}else {
				Debug.LogError("Config sprite for "+ this.gameObject.name);
			}
		}
	}

	//TODO REMOVE THIS METHOD
	void SimulateWin ()
	{
		levelManager.LoadNextLevel();
	}

	public static int BrickCount ()
	{
		return BREAKABLE_COUNT;
	}

	public static void ResetBrickCount ()
	{
		BREAKABLE_COUNT = 0;
	}
}
