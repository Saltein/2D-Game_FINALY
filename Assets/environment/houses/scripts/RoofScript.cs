using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofScript : MonoBehaviour
{
    public GameObject roof;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        roof.SetActive(false);
        Debug.Log(collision.gameObject.tag);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        roof.SetActive(true);
    }

}
