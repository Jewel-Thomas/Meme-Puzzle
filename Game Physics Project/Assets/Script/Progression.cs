using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    // Creating a Singleton class that deals with the progression of the game
    public static Progression Instance;
    public static int levelIndex;
    // public int check;
    public AudioSource sfxAudio;
    void Awake()
    {
        // check = levelIndex;
        if(Instance)
        {
            DontDestroyOnLoad(Instance.gameObject);
            Destroy(Instance.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(Instance.gameObject);
    }

    void Update()
    {
        // check = levelIndex;
    }

    public void SetLevelIdentifier(int level)
    {
        levelIndex = level;
    }
    
}
