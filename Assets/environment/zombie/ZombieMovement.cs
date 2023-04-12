using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    GameObject target;
    GameObject mainTarget;
    float speed = 2f;
    float obstacleDistance = 50f;
    float angle;

    float ang;
    float angR;

    float mainAng;
    float mainAngR;

    float timer = 0;
    float waitTime;
    float defaultSpeed;

    public int typeOfZombie;

    [SerializeField] GameObject eyes;
    [SerializeField] GameObject head;
    [SerializeField] GameObject shadow;

    private Rigidbody2D rb;
    private Vector2 movement;
    Vector2 direction;
    Vector2 mainDirection;
    Vector2 randomDirection;

    private void Awake()
    {
        target = GameObject.FindWithTag("playerBody");
        mainTarget = GameObject.FindWithTag("mainTarget");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        defaultSpeed = speed;
        typeOfZombie = Random.Range(0, 5);
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

        mainDirection = (mainTarget.transform.position - transform.position).normalized;
        mainAng = Mathf.Atan2(mainDirection.x, mainDirection.y) * Mathf.Rad2Deg;
        RaycastHit2D mainHit = Physics2D.Raycast(eyes.transform.position, mainDirection, 1000);
        Debug.DrawRay(eyes.transform.position, mainDirection * 100, Color.red);



        // поворот
        transform.rotation = Quaternion.Euler(0, 0, -ang);

        if (hit.collider != null && typeOfZombie/2 != 0)
        {
            if (hit.collider.tag == "playerBody" || hit.collider.tag == "Zombie")
            {
                movement = direction * speed;
                head.transform.rotation = Quaternion.Euler(0, 0, -ang);
            }
            else
            {
                head.transform.rotation = Quaternion.Euler(0, 0, -angR);
                if (timer >= (waitTime))
                {
                    SetRandomAngle();
                    waitTime = Random.Range(0.3f, 2f);
                    timer = 0;
                }
                randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                movement = randomDirection * speed;
            }
            shadow.transform.rotation = transform.rotation;
        }
        else
        {
            head.transform.rotation = Quaternion.Euler(0, 0, -angR);
            if (timer >= (waitTime))
            {
                SetRandomAngle();
                waitTime = Random.Range(0.3f, 2f);
                timer = 0;
            }
            randomDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            movement = randomDirection * speed;
        }

        //--------------
        if (typeOfZombie/2 == 0)
        {
            movement = mainDirection * speed;
            head.transform.rotation = Quaternion.Euler(0, 0, -mainAng);
            shadow.transform.rotation = head.transform.rotation;
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