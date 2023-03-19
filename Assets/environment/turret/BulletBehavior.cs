using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 100f;
    private float fieldOfView = 50f;

    Rigidbody2D rb;
    float[] startPos = new float[2];

    private void Start()
    {
        startPos[0] = transform.position.x; startPos[1] = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = transform.up * bulletSpeed;
    }

    private void FixedUpdate()
    {
        float diffX = transform.position.x - startPos[0];
        float diffY = transform.position.y - startPos[1];
        float diffXY = Mathf.Sqrt(diffX * diffX + diffY * diffY);

        if (Mathf.Abs(diffXY) > fieldOfView)
        {
            Destroy(gameObject);
        }
    }
}
