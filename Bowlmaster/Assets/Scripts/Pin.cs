using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float stadingThreshold=45;

	// Use this for initialization
	void Start () {
	
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
}
