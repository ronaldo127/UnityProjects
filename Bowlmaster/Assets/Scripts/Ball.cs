using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
	public bool inPlay = false;

	private AudioSource rollingSound;
	private Rigidbody rigidBody;
	private Vector3 startPosition;
	private Quaternion startRotation;

	void Start () {
		SetupVariables ();
	}

	void SetupVariables ()
	{
		rigidBody = GetComponent<Rigidbody> ();
		rollingSound = GetComponent<AudioSource> ();
		startPosition = transform.position;
		startRotation = transform.rotation;

		rigidBody.useGravity = false;
	}

	public void Launch (Vector3 velocity)
	{
		rigidBody.useGravity = true;
		rigidBody.velocity = (velocity);
		rollingSound.Play ();
		inPlay = true;
	}

	public void Reset ()
	{
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		transform.position = startPosition;
		transform.rotation = startRotation;
		inPlay = false;
	}
}
