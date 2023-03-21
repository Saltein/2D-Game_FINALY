using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movament : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float camSpeed = 0.03f;

    [SerializeField] private GameObject head; // персонаж, голова
    [SerializeField] private GameObject target; // там, где указатель мыши
    [SerializeField] private GameObject middle; // там, где будет камера стоять
    public Camera cam; // камера собственно

    private float moveX;
    private float moveY;

    private float timer;

    private float dashTime = 0.1f;
    private float sprintSpeed;
    private float oldSpeed;
    private float newSpeed;

    private float staminaDecrease = 40f;
    private float staminaIncrease = 15f;
    private float staminaDash = 30f;

    private float s = 1;
    private float s1 = 1;

    private bool IsDash = false;
    private bool IsRunning = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldSpeed = speed;
        sprintSpeed = oldSpeed * 2;
        Debug.Log(oldSpeed.ToString() + "\n" + sprintSpeed.ToString());
    }

    private void Update()
    {
        // Камера
        float midX = (head.transform.position.x + target.transform.position.x) / 2;
        float midY = (head.transform.position.y + target.transform.position.y) / 2;

        middle.transform.position = new Vector3(midX, midY, 0);

        Vector3 camPos = cam.transform.position;
        Vector3 playPos = new Vector3(middle.transform.position.x, middle.transform.position.y, -10f);
        cam.transform.position = Vector3.Lerp(camPos, playPos, camSpeed);

        // Бег и стамина
        if (PlayerManager.playerStamina > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                IsRunning = true;
                s *= 1.7f;
            }
            if (IsRunning)
            {
                PlayerManager.playerStamina -= Time.deltaTime * staminaDecrease;
            }
        }
        else
        {
            s = s1;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsRunning = false;
            s = s1;
        }

        if (!Input.GetKey(KeyCode.LeftShift) && PlayerManager.playerStamina < 100f)
        {
            PlayerManager.playerStamina += Time.deltaTime * staminaIncrease;
        }

        if (PlayerManager.playerStamina > 100) { PlayerManager.playerStamina = 100; }
        if (PlayerManager.playerStamina < 0) { PlayerManager.playerStamina = 0; }

        // Рывок
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerManager.playerStamina > staminaDash)
            {
                PlayerManager.playerStamina -= staminaDash;
                timer = 0f;
                if (timer <= dashTime && !IsDash)
                {
                    newSpeed = oldSpeed * 5;
                    IsDash = true;
                }
            }
        }
        if (timer >= dashTime) { newSpeed = oldSpeed; IsDash = false; }
        timer += Time.deltaTime;

        speed = newSpeed;
    }

    void FixedUpdate()
    {
        // Ходьба
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(moveX, moveY) * speed * s;

        // Поворот
        target.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = target.transform.position - head.transform.position;
        float rotat = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
        head.transform.rotation = Quaternion.Euler(0f, 0f, -rotat);
    }
}
