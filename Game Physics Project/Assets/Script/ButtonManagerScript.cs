using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject titlePanel;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !titlePanel.gameObject.activeInHierarchy)
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }        
    }

    // Function used to Resume the game and deactivate the pause menu
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    // Function used to Pause the game and activate the pause menu
    void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    // Function to get to the puzzle selected by the player
    public void PuzzleSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PiecesScript.remaining = 36;
        GameManagerScript.timeBarParent.SetActive(false);
        GameManagerScript.isPuzzling = false;
    }
    // Function for Quitting the game
    public void NextScene()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
