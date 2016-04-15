using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	public Ball ball;

	private float dragStartTime;
	private Vector3 dragStartMousePosition;
	private bool isLaunched = false;
	private GameObject floor;

	void Start () {
		ball = GetComponent<Ball>();
		floor = GameObject.Find("Floor");
		if (!floor) Debug.LogError("There is no Floor!");
	}

	public void DragStart(){
		if (isLaunched) return;

		dragStartTime = Time.timeSinceLevelLoad;
		dragStartMousePosition = Input.mousePosition;
	}

	public void DragEnd () {
		if (isLaunched) return;

		Vector3 diffPosition = Input.mousePosition - dragStartMousePosition;
		float diffTime = Time.timeSinceLevelLoad - dragStartTime;

		float floorDistance = floor.transform.lossyScale.z*0.6f;
		Vector3 launchVector = new Vector3(diffPosition.x, 0, Mathf.Clamp(diffPosition.y/diffTime, 0, floorDistance));
		ball.Launch(launchVector);

		isLaunched = true;
	}

	public void MoveStart (float x)
	{
		if (isLaunched) return;

		float radius = this.transform.lossyScale.x/2;
		float minX = floor.transform.position.x-floor.transform.lossyScale.x/2+radius;
		float maxX = floor.transform.position.x+floor.transform.lossyScale.x/2-radius;
		Vector3 pos = this.transform.position;
		this.transform.position=new Vector3(Mathf.Clamp(pos.x+x, minX, maxX), pos.y, pos.z);
	}
}
