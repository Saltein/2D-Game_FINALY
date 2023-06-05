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

    [SerializeField] private TextMeshProUGUI brickWall;
    [SerializeField] private TextMeshProUGUI brickWallCountTxt;

    [SerializeField] private TextMeshProUGUI ammo7_62;
    [SerializeField] private TextMeshProUGUI ammo7_62CountTxt;

    [SerializeField] private TextMeshProUGUI grenade;
    [SerializeField] private TextMeshProUGUI grenadeCountTxt;

    public static int bandageCount = 0;
    public static int barbedWireCount = 5;
    public static int brickWallCount = 5;
    public static int ammo7_62Count;
    public static int grenadeCount = 3;

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

        if (Input.GetKeyDown(KeyCode.Tab) && !PauseMenu.IsPauseMenuOpen)
        {
            IsOpen = !IsOpen;
        }


        // -------------------- крафт --------------------
        bandageCountTxt.text = "x" + bandageCount.ToString();
        barbedWireCountTxt.text = "x" + barbedWireCount.ToString();
        brickWallCountTxt.text = "x" + brickWallCount.ToString();
        ammo7_62CountTxt.text = "x" + (Weapon.ammoOutCount + Weapon.ammoCount).ToString();
        grenadeCountTxt.text = "x" + grenadeCount.ToString();

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

        // кирпичная стена
        if (brickAm >= 8)
        {
            brickWall.color = Color.white;
        }
        else { brickWall.color = Color.gray; }

        // патроны 7.62
        if (scrapAm >= 3 && chemicAm >= 2)
        {
            ammo7_62.color = Color.white;
        }
        else { ammo7_62.color = Color.gray; }

        // граната
        if (scrapAm >= 20 && chemicAm >= 15)
        {
            grenade.color = Color.white;
        }
        else { grenade.color = Color.gray; }
    }
}
