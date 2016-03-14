using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float sideSpeed = 5f;
    public float downSpeed = 0.5f;

    private float xMin = -5f;
    private float xMax = 5f;

    private bool moveLeft = true;

    // Use this for initialization
    void Start () {
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMost.x + width / 2;
        xMax = rightMost.x - width / 2;
    }

    // Update is called once per frame
    void Update() {
        if (moveLeft) {
            this.transform.position += Vector3.left * sideSpeed * Time.deltaTime;
        }
        else { 
            this.transform.position += Vector3.right * sideSpeed * Time.deltaTime;
        }

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,xMin,xMax), this.transform.position.y, this.transform.position.z);

        if (transform.position.x <= xMin || transform.position.x >= xMax)
        {
            moveLeft = !moveLeft;
            this.transform.position += Vector3.down * downSpeed;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height));
    }
}
