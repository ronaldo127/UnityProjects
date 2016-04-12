using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public float stopZ=1829;

	private Vector3 offset;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		offset = this.transform.position-ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.z < stopZ)
			this.transform.position = ball.transform.position + offset;
	}
}
