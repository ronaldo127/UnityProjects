using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public float hp = 100f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5;
    public float shotsPerSecond = 0.5f;

    private BoxCollider2D myCollider;
    private ScoreKeeper score;

    public AudioClip enemyHit;
    public AudioClip enemyShot;
    public AudioClip enemyDead;

    // Use this for initialization
    void Start () {
        myCollider = this.GetComponent<BoxCollider2D>();
        score = GameObject.FindObjectOfType<ScoreKeeper>();
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
        AudioSource.PlayClipAtPoint(enemyShot, transform.position);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Bullet bullet = coll.gameObject.GetComponent<Bullet>();
        if (bullet) { 
            hp -= bullet.damage;
            bullet.Hit();
            AudioSource.PlayClipAtPoint(enemyHit, transform.position);
            if (hp <= 0)
            {
                score.Score(Mathf.FloorToInt(bullet.damage));
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(enemyDead, transform.position);
            }
        }
    }
}
