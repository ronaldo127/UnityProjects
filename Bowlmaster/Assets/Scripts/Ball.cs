using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

	public float initialVelocity = 1f;
	private AudioSource rollingSound;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		SetupVariables ();
		Launch ();
	}

	void SetupVariables ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		rollingSound = GetComponent<AudioSource> ();
	}

	public void Launch ()
	{
		rigidBody.velocity = ( Vector3.forward * initialVelocity);
		rollingSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
