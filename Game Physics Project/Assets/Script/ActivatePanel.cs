using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    public GameObject panel;
    public bool onWork = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Progression.levelIndex>2 && !onWork)
        {
            StartCoroutine(StartPanel());
            onWork = !onWork;
        }
    }

    IEnumerator StartPanel()
    {
        yield return new WaitForSeconds(5);
        panel.SetActive(true);
    }
}
