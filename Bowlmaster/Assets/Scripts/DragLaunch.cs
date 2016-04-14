using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	public Ball ball;
	private float dragStartTime;
	private Vector3 dragStartMousePosition;

	void Start () {
		ball = GetComponent<Ball>();
		print(ball);
	}

	public void DragStart(){
		dragStartTime = Time.timeSinceLevelLoad;
		dragStartMousePosition = Input.mousePosition;
	}

	public void DragEnd () {
		Vector3 diffPosition = Input.mousePosition - dragStartMousePosition;
		float diffTime = Time.timeSinceLevelLoad - dragStartTime;

		Vector3 launchVector = new Vector3(diffPosition.x, 0, diffPosition.y/diffTime);
		ball.Launch(launchVector);
	}
}
