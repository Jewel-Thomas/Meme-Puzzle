using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCG : MonoBehaviour
{

    public static BCG Instance;  
    void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
