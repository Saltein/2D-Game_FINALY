using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 100f;

    private float fieldOfView = 50f;
    private float timer = 0;

    private bool IsHit = false;

    public GameObject Brick_react;
    public GameObject Wood_react;
    public GameObject Metal_react;
    public GameObject Blood_react;


    Rigidbody2D rb;
    float[] startPos = new float[2];

    private void Start()
    {
        
        startPos[0] = transform.position.x; startPos[1] = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!IsHit)
        {
            rb.velocity = transform.up * bulletSpeed;
        }
        else
        {
            rb.velocity = transform.up * Mathf.Lerp(bulletSpeed, 0f, 5f);
        }

        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            Destroy(gameObject);
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsHit = true;
        Destroy(gameObject);
        if (collision.gameObject.tag == "From_brick")
        {
            Instantiate(Brick_react, transform.position, transform.rotation);
        }
        if (collision.gameObject.tag == "From_wood")
        {
            Instantiate(Wood_react, transform.position, transform.rotation);
        }
        if (collision.gameObject.tag == "From_metal")
        {
            Instantiate(Metal_react, transform.position, transform.rotation);
        }
        if (collision.gameObject.tag == "Zombie")
        {
            Instantiate(Blood_react, transform.position, transform.rotation);
        }

    }
}
