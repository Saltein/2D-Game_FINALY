using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barbedWireScript : MonoBehaviour
{
    [SerializeField] GameObject frame;

    bool IsPlaced;
    private RectTransform rectTransform;

    private Vector3 mousePosition;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlaced)
        {
            if (collision.gameObject.tag == "playerBody")
            {
                PlayerManager.Damage(5);
            }
        }
    }
}
