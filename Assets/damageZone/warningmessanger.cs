using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class warningmessanger : MonoBehaviour
{
    [SerializeField] GameObject WarningText;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            WarningText.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBody")
        {
            WarningText.SetActive(false);
        }
    }
}
