using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class newZombieMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    float obstacleDistance = 50f;
    float speed = 0.2f;
    float angle;
    float timer = 0f;
    float reangleTime = 3f;
    float ang;

    GameObject player;
    GameObject lenin;

    public GameObject eyes;

    Vector2 randomDirection;
    Vector2 direction;
    Vector2 movement;


    private void Awake()
    {
        player = GameObject.FindWithTag("playerBody");
        lenin = GameObject.FindWithTag("mainTarget");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        direction = (player.transform.position - transform.position).normalized;
        
        RaycastHit2D hit = Physics2D.Raycast(eyes.transform.position, direction, 500f);
        Debug.DrawRay(eyes.transform.position, direction * obstacleDistance);

        if (hit.collider.tag == "playerBody" || hit.collider.tag == "playerHead" || hit.collider.tag == "Zombie" || hit.collider.tag == "bullet_ak-47")
        {
            movement = direction * speed;
            ang = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        }
        else
        {
            if (timer >= reangleTime)
            {
                angle = Random.Range(0, 6.28f);
                randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                reangleTime = Random.Range(2, 10);
                timer = 0f;
            }
            movement = randomDirection * speed;
            ang = Mathf.Atan2(randomDirection.x, randomDirection.y) * Mathf.Rad2Deg;
        }

        Debug.LogAssertion(hit.collider.tag);

        transform.rotation = Quaternion.Euler(0, 0, -ang);
        rb.velocity = movement;
    }
}
