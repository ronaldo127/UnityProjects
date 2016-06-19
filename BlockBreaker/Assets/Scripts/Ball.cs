using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float angularPaddleFactor = 1f;
	[Range(0.0f, 45.0f)]
	public float openAngle = 45.0f;

	private Paddle paddle;

	private bool hasStarted;
	private Rigidbody2D rb;
	private AudioSource audioClip;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		rb = GetComponent<Rigidbody2D>();
		audioClip = GetComponent<AudioSource>();
		hasStarted = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			this.transform.position = new Vector3(paddle.transform.position.x, this.transform.position.y, this.transform.position.z);

			if (Input.GetMouseButtonDown (0)) {
				rb.velocity = new Vector2(2.0f,10.0f);
				hasStarted = true;
			}

		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (hasStarted) {
			audioClip.Play ();
			if (collision.gameObject.name == "Paddle") {
				Vector2 tweak = new Vector2 ((this.transform.position.x-paddle.transform.position.x)*angularPaddleFactor, 0f);
				Vector2 oldV = this.rb.velocity;
				float size = oldV.magnitude;
				Vector2 newV = (oldV+tweak).normalized*size;
				float angleDeg = (Mathf.Atan2(newV.y, newV.x) * Mathf.Rad2Deg + 360.0f) % 360.0f;
				float minAng = 180.0f + openAngle;
				float maxAng = 360.0f - openAngle;
				if ( angleDeg < minAng || angleDeg > maxAng ){
					float tanValue = Mathf.Tan(Mathf.Clamp(angleDeg, minAng, maxAng)*Mathf.Deg2Rad);
					newV = new Vector2 (-tanValue, 1).normalized*size;
				}
				this.rb.velocity = newV;
			}
		}
	}
}
