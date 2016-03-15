using UnityEngine;
using System.Collections;
using System;

public class FormationController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float sideSpeed = 5f;
    public float downSpeed = 0.5f;
    public float spawnDelay = 0.5f;

    private float xMin = -5f;
    private float xMax = 5f;

    private bool moveLeft = true;

    // Use this for initialization
    void Start()
    {
        SpawnUntilFull();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMost.x + width / 2;
        xMax = rightMost.x - width / 2;
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            this.transform.position += Vector3.left * sideSpeed * Time.deltaTime;
        }
        else {
            this.transform.position += Vector3.right * sideSpeed * Time.deltaTime;
        }

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, xMin, xMax), this.transform.position.y, this.transform.position.z);

        if (transform.position.x <= xMin || transform.position.x >= xMax)
        {
            moveLeft = !moveLeft;
            this.transform.position += Vector3.down * downSpeed;
        }

        if (EveryoneIsDead())
        {
            SpawnUntilFull();
        }
    }

    private Transform NextFreePosition()
    {
        foreach (Transform positionGameObject in this.transform)
        {
            if (positionGameObject.childCount == 0) return positionGameObject;
        }
        return null;
    }

    private bool EveryoneIsDead()
    {
        int aliveChildren = this.transform.childCount;
        foreach (Transform positionGameObject in this.transform)
        {
            if (positionGameObject.childCount == 0) aliveChildren--;
        }
        return aliveChildren == 0;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
