using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public float maxX = 9.0f;
	public float maxY = 5.0f;

	private GameObject defenders;
	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		defenders = GameObject.Find("Defenders");
		if (defenders==null)
			defenders = new GameObject("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	void OnMouseDown ()
	{
		if (SpawnButton.GetCurrentSelected ()) {
			int cost = SpawnButton.GetCurrentSelected ().GetComponent<Defender> ().cost;
			Vector3 dest = GetMouseClickInGrid ();
			if (CanAttach (dest)) {
				if (starDisplay.UseStars (cost)) {
					SnapToGrid (dest);
				} else {
					SpawnButton.CantSpawnMessage ();
				}
			}
		}
	}

	private void SnapToGrid (Vector3 dest)
	{
		GameObject defender = Instantiate (SpawnButton.GetCurrentSelected (), dest, Quaternion.identity) as GameObject;
		defender.transform.parent = defenders.transform;
	}

	private bool CanAttach (Vector3 dest)
	{
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll (dest, 0.4f);
		int counter = 0;
		foreach (Collider2D collider in hitColliders) {
			if (!collider.GetComponent<Projectile>()){
				counter++;
			}
		}
		return counter < 2;
	}

	private Vector3 GetMouseClickInGrid ()
	{
		Vector3 temp = Input.mousePosition;
		temp.z = transform.position.z-Camera.main.transform.position.z;
		temp = Camera.main.ScreenToWorldPoint(temp);
		return new Vector3(Mathf.Clamp(Mathf.Round(temp.x), 1.0f, maxX),
							Mathf.Clamp(Mathf.Round(temp.y), 1.0f, maxY),
							 0);
	}
}
