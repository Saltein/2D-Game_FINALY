using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeninManager : MonoBehaviour
{
    public static int leninHP = 3000;
    public Image HPBar;

    private void Update()
    {
        HPBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, leninHP/10);
    }

    public static void Damage(int damageCount)
    {
        leninHP -= damageCount;

        if (leninHP <= 0)
        {
            leninHP = 3000;
            PlayerManager.gameOver = true;
        }
    }
}
