using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	private Ball ball;
	private float minX;
	private float maxX;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		minX = Camera.main.ScreenToWorldPoint (new Vector3(0.0f,0,0)).x;
		maxX = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width,0,0)).x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}
	private void AutoPlay ()
	{
		this.transform.position= new Vector3(
			Mathf.Clamp(ball.transform.position.x, -1.0f, 17.0f),
			this.transform.position.y,
			this.transform.position.z);		
	}

	private void MoveWithMouse ()
	{
		Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		this.transform.position= new Vector3(
			Mathf.Clamp(worldPos.x, -1.0f, 17.0f),
			this.transform.position.y,
			this.transform.position.z);
	}
}
