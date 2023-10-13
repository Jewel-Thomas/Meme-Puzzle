using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyText3 : MonoBehaviour
{
    public TextMeshProUGUI score3;
    void Update()
    {
        score3.text = $"Puzzle 3 : {ScoreManager.scores[2]}";
    }
}
