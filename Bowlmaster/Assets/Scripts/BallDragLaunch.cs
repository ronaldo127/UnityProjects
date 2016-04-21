using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private float dragStartTime;
	private Vector3 dragStartMousePosition;
	private GameObject floor;

	void Start () {
		ball = GetComponent<Ball>();
		floor = GameObject.Find("Floor");
		if (!floor) Debug.LogError("There is no Floor!");
	}

	public void DragStart(){
		if (ball.inPlay) return;

		dragStartTime = Time.timeSinceLevelLoad;
		dragStartMousePosition = Input.mousePosition;
	}

	public void DragEnd () {
		if (ball.inPlay) return;

		Vector3 diffPosition = Input.mousePosition - dragStartMousePosition;
		float diffTime = Time.timeSinceLevelLoad - dragStartTime;

		float floorDistance = floor.transform.lossyScale.z*0.6f;
		Vector3 launchVector = new Vector3(diffPosition.x, 0, Mathf.Clamp(diffPosition.y/diffTime, 0, floorDistance));
		ball.Launch(launchVector);

	}

	public void MoveStart (float x)
	{
		if (ball.inPlay) return;

		float radius = this.transform.lossyScale.x/2;
		float minX = floor.transform.position.x-floor.transform.lossyScale.x/2+radius;
		float maxX = floor.transform.position.x+floor.transform.lossyScale.x/2-radius;
		Vector3 pos = this.transform.position;
		this.transform.position=new Vector3(Mathf.Clamp(pos.x+x, minX, maxX), pos.y, pos.z);
	}
}
