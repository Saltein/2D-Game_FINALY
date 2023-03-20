using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    private static bool IsOpen = false;

    [SerializeField] private TextMeshProUGUI Sc;
    [SerializeField] private TextMeshProUGUI Ch;
    [SerializeField] private TextMeshProUGUI Ra;
    [SerializeField] private TextMeshProUGUI Wo;
    [SerializeField] private TextMeshProUGUI Br;

    public static int scrapAm = 0, chemicAm = 0, ragAm = 0, woodAm = 0, brickAm = 0;

    [SerializeField] private GameObject invPanel;

    private void Start()
    {
        invPanel.SetActive(false);
    }
    private void Update()
    {
        Sc.text = "" + scrapAm;
        Ch.text = "" + chemicAm;
        Ra.text = "" + ragAm;
        Wo.text = "" + woodAm;
        Br.text = "" + brickAm;


        if (IsOpen)
        {
            invPanel.SetActive(true);
        }
        else
        {
            invPanel.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            IsOpen = !IsOpen;
            Debug.Log("IsOpen " + IsOpen.ToString());
        }
    }
}
