using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintCounter : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public static int hintsLeft;
    // Start is called before the first frame update
    void Start()
    {
        hintsLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        hintText.text = $"{hintsLeft}";
    }
}
