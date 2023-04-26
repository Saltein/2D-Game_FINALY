using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LootScript : MonoBehaviour
{
    private bool IsEnoughClose = false;
    Vector3 playerPos;

    void Update()
    {
        if (IsEnoughClose)
        {
            transform.position = Vector3.Lerp(transform.position, playerPos, 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerHead")
        {
            playerPos = collision.transform.position;
            IsEnoughClose = true;
            
        }
        Debug.Log(collision.tag);
    }
}
