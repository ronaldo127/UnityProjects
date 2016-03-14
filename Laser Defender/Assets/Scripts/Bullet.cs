using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 5.0f;
    public float damage = 100f;
    
    private float yMin;
    private float yMax;

    private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start ()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 highestPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        yMax = highestPosition.y + boxCollider.size.y / 2; 
        Vector3 lowestPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        yMin = lowestPosition.y - boxCollider.size.y/2;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (!(this.transform.position.y<=yMax&&this.transform.position.y>=yMin))
        {
            Destroy(this.gameObject);
        }
	}
}
