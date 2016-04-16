using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float stadingThreshold=45;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	}


	public bool IsStanding ()
	{
		Vector3 angles = transform.rotation.eulerAngles;
		float xAngle = angles.x;
		float zAngle = angles.z;
		return (Mathf.Abs(xAngle-360.0f)<stadingThreshold || xAngle<stadingThreshold) && 
			(zAngle<stadingThreshold || Mathf.Abs(zAngle-360.0f)<stadingThreshold);
	}

	public void Raise (float distanceToRaise)
	{
		if (this.IsStanding ()) {
			this.transform.Translate(Vector3.up*distanceToRaise, Space.World);
			rb.useGravity = false;
			rb.angularVelocity = Vector3.zero;
			rb.velocity = Vector3.zero;
		}
	}
	public void Lower (float distanceToRaise)
	{
		if (this.IsStanding ()) {
			this.transform.Translate (Vector3.down * distanceToRaise, Space.World);
			rb.useGravity = true;
		}
	}
}
