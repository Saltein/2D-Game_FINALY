using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP;
    public static float playerStamina;
    public static bool gameOver;

    public TextMeshProUGUI HPTxt;
    public Image HPBar;
    public Image StaminaBar;

    private void Start()
    {
        playerStamina = 100f;
        playerHP = 100;
        gameOver = false;
    }

    private void Update()
    {
        HPTxt.text = "" + playerHP;
        HPBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, playerHP);
        StaminaBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, playerStamina);

        if (gameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public static void Damage(int damageCount)
    {
        playerHP -= damageCount;

        if (playerHP <= 0)
        {
            gameOver = true;
        }
    }
}
