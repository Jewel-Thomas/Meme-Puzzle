using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyText2 : MonoBehaviour
{
    public TextMeshProUGUI score2;
    void Update()
    {
        score2.text = $"Puzzle 2 : {ScoreManager.scores[1]}";
    }
}
