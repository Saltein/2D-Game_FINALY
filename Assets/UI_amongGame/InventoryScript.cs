using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    public static bool IsOpen = false;

    [SerializeField] private TextMeshProUGUI Sc;
    [SerializeField] private TextMeshProUGUI Ch;
    [SerializeField] private TextMeshProUGUI Ra;
    [SerializeField] private TextMeshProUGUI Wo;
    [SerializeField] private TextMeshProUGUI Br;

    [SerializeField] private TextMeshProUGUI bandage;
    [SerializeField] private TextMeshProUGUI bandageCountTxt;

    [SerializeField] private TextMeshProUGUI barbedWire;
    [SerializeField] private TextMeshProUGUI barbedWireCountTxt;

    public static int bandageCount = 0;
    public static int barbedWireCount = 5;

    public static int scrapAm = 0, chemicAm = 0, ragAm = 0, woodAm = 0, brickAm = 0;

    [SerializeField] private GameObject invPanel;

    private void Start()
    {
        invPanel.SetActive(false);
        bandage.color = Color.gray;
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
        }


        // -------------------- крафт --------------------
        bandageCountTxt.text = "x" + bandageCount.ToString();
        barbedWireCountTxt.text = "x" + barbedWireCount.ToString();
        // бинты
        if (ragAm >= 2)
        {
            bandage.color = Color.white;
        }
        else { bandage.color = Color.gray; }
        // колючая проволока
        if (scrapAm >= 8)
        {
            barbedWire.color = Color.white;
        }
        else { barbedWire.color = Color.gray; }
    }
}
