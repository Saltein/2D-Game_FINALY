using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movament : MonoBehaviour
{

    [SerializeField] private float speed = 0.03f;
    [SerializeField] private float camSpeed = 0.03f;
    [SerializeField] private GameObject head;
    [SerializeField] private GameObject target;
    [SerializeField] private Camera cam;


    void FixedUpdate()
    {
        // Ходьба
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        transform.position += new Vector3(moveX, moveY) * speed;

        // Поворот
        target.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = target.transform.position - head.transform.position;
        float rotat = Mathf.Atan2(diff.x, diff.y) * Mathf.Rad2Deg;
        head.transform.rotation = Quaternion.Euler(0f, 0f, -rotat);

        // Камера
        Vector3 camPos = cam.transform.position;
        Vector3 playPos = new Vector3(transform.position.x, transform.position.y, -10f);
        cam.transform.position = Vector3.Lerp(camPos, playPos, camSpeed);
    }
}
