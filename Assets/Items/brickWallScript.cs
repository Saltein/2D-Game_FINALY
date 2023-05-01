using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickWallScript : MonoBehaviour
{
    [SerializeField] private GameObject frame;

    bool IsPlaced;
    private RectTransform rectTransform;

    private Vector3 mousePosition;

    public int brickWallHP = 10;
    float timer;
    float damageTime = 0.5f;
    int buildingsDamage = 10;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        IsPlaced = false;
    }

    void Update()
    {
        if (!IsPlaced)
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
            float rotation = Input.GetAxis("Mouse ScrollWheel");
            rectTransform.Rotate(new Vector3(0, 0, rotation * 50));
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            IsPlaced = true;
            frame.SetActive(false);
        }
        if (brickWallHP <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlaced)
        {
            if (collision.gameObject.tag == "Zombie")
            {
                brickWallHP -= 2;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (timer >= damageTime && collision.gameObject.tag == "Zombie")
        {
            brickWallHP -= buildingsDamage;
            timer = 0;
        }
    }
}
