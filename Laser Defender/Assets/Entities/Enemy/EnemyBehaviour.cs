using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float hp = 100f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5;
    public float shotsPerSecond = 0.5f;

    private BoxCollider2D myCollider;

    // Use this for initialization
    void Start () {
        myCollider = this.GetComponent<BoxCollider2D>();

    }
	
	// Update is called once per frame
	void Update () {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value<probability) { 
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position + Vector3.down * myCollider.size.y, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = Vector3.down * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Bullet bullet = coll.gameObject.GetComponent<Bullet>();
        if (bullet) { 
            hp -= bullet.damage;
            bullet.Hit();
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
