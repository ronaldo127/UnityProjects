using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)]
	public float currentSpeed;
	public float defaultSpeed;


	// Use this for initialization
	void Start () {
		defaultSpeed = currentSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.left*currentSpeed*Time.deltaTime);
	}

	public void SetSpeed(float speed){
		this.currentSpeed = speed;
	}

	public void SetDefaultSpeed(){
		this.currentSpeed = this.defaultSpeed;
	}

}
