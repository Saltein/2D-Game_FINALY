using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScriptForBTNS : MonoBehaviour
{
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Ñ×¨t: " + PlayerManager.PlayerScore;
    }
    public void CraftScore()
    {
        PlayerManager.PlayerScore += 10;
    }
}
