using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP;
    public static float playerStamina;
    public static bool gameOver;
    public static int PlayerScore;

    public TextMeshProUGUI HPTxt;
    public Image HPBar;
    public Image StaminaBar;
    public static Transform currentTrans;

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
        currentTrans = transform;
        
        
    }

    public static void Damage(int damageCount)
    {
        playerHP -= damageCount;

        if (playerHP <= 0)
        {
            gameOver = true;
            PlayerScore = 0;
            Day_Night_Change.timerDays = 1;
            Day_Night_Change.timerHours = 6;
            Day_Night_Change.timerMinutes = 0;
}
    }

    
        



}
