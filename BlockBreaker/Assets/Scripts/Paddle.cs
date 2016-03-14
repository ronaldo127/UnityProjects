using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
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
			Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f),
			this.transform.position.y,
			this.transform.position.z);		
	}

	private void MoveWithMouse ()
	{
		this.transform.position= new Vector3(
			Mathf.Clamp(Input.mousePosition.x/Screen.width*16, 0.5f, 15.5f),
			this.transform.position.y,
			this.transform.position.z);
	}
}
