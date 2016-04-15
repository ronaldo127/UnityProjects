using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {

	private AudioSource rollingSound;
	private Rigidbody rigidBody;

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
}
