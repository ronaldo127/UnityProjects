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
	}

	void SetupVariables ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		rollingSound = GetComponent<AudioSource> ();

		rigidBody.useGravity = false;
	}

	public void Launch (Vector3 velocity)
	{
		rigidBody.useGravity = true;
		rigidBody.velocity = (velocity);
		rollingSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
