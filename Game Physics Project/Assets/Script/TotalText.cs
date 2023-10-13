using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalText : MonoBehaviour
{
    public TextMeshProUGUI score4;
    void Update()
    {
        score4.text = $"Total : {ScoreManager.scores[0] + ScoreManager.scores[1] + ScoreManager.scores[2]}";
    }
}
