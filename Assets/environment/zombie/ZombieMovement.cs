using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    GameObject target;
    float speed = 2f;
    float obstacleDistance = 15f;
    float angle;
    float ang;
    float angR;
    float timer = 0;
    float waitTime;
    float defaultSpeed;

    [SerializeField] GameObject eyes;
    [SerializeField] GameObject head;

    private Rigidbody2D rb;
    private Vector2 movement;
    Vector2 direction;
    Vector2 randomDirection;

    private void Awake()
    {
        target = GameObject.FindWithTag("playerBody");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        defaultSpeed = speed;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        direction = (target.transform.position - transform.position).normalized;
        ang = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        angR = Mathf.Atan2(randomDirection.x, randomDirection.y) * Mathf.Rad2Deg;
        RaycastHit2D hit = Physics2D.Raycast(eyes.transform.position, direction, obstacleDistance);
        Debug.DrawRay(eyes.transform.position, direction * obstacleDistance);

        // поворот
        transform.rotation = Quaternion.Euler(0, 0, -ang + 90);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "playerBody" || hit.collider.tag == "Zombie")
            {
                movement = direction * speed;
                head.transform.rotation = Quaternion.Euler(0, 0, -ang + 90);
            }
            else
            {
                head.transform.rotation = Quaternion.Euler(0, 0, -angR + 90);
                if (timer >= (waitTime))
                {
                    SetRandomAngle();
                    waitTime = Random.Range(0.3f, 2f);
                    timer = 0;
                }
                randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                movement = randomDirection * speed;
            }
        }
        else
        {
            head.transform.rotation = Quaternion.Euler(0, 0, -angR + 90);
            if (timer >= (waitTime))
            {
                SetRandomAngle();
                waitTime = Random.Range(0.3f, 2f);
                timer = 0;
            }
            randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            movement = randomDirection * speed;
        }
        rb.velocity = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "barbedWire") { speed = 0.5f; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "barbedWire") { speed = defaultSpeed; }
    }

    void SetRandomAngle()
    {
        angle = Random.Range(0, 6.28f);
    }
}