using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyText1 : MonoBehaviour
{
    public TextMeshProUGUI score1;
    void Update()
    {
        score1.text = $"Puzzle 1 : {ScoreManager.scores[0]}";
    }
}
