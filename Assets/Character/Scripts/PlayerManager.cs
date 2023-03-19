using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP;
    public static bool gameOver;

    public TextMeshProUGUI HPTxt;
    public Image HPBar;

    private void Start()
    {
        playerHP = 100;
        gameOver = false;
    }

    private void Update()
    {
        HPTxt.text = "" + playerHP;
        HPBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, playerHP);

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
