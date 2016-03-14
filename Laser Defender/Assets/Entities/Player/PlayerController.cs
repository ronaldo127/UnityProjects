using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject bulletPrefab;

    public float speed=5;
    public float firingRate = 0.2f;

    public float bulletSpeed = 5;

    public float hp = 250;

    private float xMin = -5;
    private float xMax = 5;

    private BoxCollider2D myCollider;

    // Use this for initialization
    void Start () {
        myCollider = GetComponent<BoxCollider2D>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMost.x + myCollider.size.x/2;
        xMax = rightMost.x - myCollider.size.x/2;
    }
	
	// Update is called once per frame
	void Update () {
        HandleMovement();
        HandleBullet();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Bullet bullet = coll.gameObject.GetComponent<Bullet>();
        if (bullet)
        {
            hp -= bullet.damage;
            bullet.Hit();
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position + Vector3.up * myCollider.size.y, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = Vector3.up * bulletSpeed;
    }

    void HandleBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(this.transform.position.x, xMin, xMax);

        transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
    }
}
