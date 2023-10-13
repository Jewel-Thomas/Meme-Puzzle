using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    [Range(0,20)] public float xClampVal;
    [Range(0,20)] public float yClampVal;
    public GameObject parentPuzzle;
    public GameObject textPanel;
    public Rigidbody2D puzzleRb;
    public bool isPuzzleSolved = false;
    public static bool isPuzzling = false;
    [SerializeField] Image timeBar;
    public static GameObject timeBarParent;
    [SerializeField] List<GameObject> pieces;
    public static List<GameObject> currentpieces;
    [SerializeField] GameObject activateRing1;
    [SerializeField] GameObject activateRing2;
    [SerializeField] Button puzzle2;
    [SerializeField] Button puzzle3;
    ButtonManagerScript buttonManagerScript;
    [SerializeField] GameObject hintGameObject;
    [SerializeField] GameObject path1;
    [SerializeField] GameObject path2;
    [SerializeField] AudioClip solvedAudio;
    [SerializeField] AudioClip DisassembleAudio;
    
    // [SerializeField] Animator ringAnim;
    float totTime;
    float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        buttonManagerScript = GetComponent<ButtonManagerScript>();
        currentpieces = pieces;
        if(Progression.levelIndex >= 1)
        {
            puzzle2.interactable = true;
        }
        if(Progression.levelIndex >= 2)
        {
            puzzle3.interactable = true;
        }
        isPuzzleSolved = false;
        timeBarParent = GameObject.Find("TimeBar");
        timeBarParent.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        DragAndDrop.clampVal = xClampVal;
        DragAndDrop.y_clampVal = yClampVal; 
        AfterSolve();
        if(isPuzzling) UpdateTime();
        if(Progression.levelIndex==1)
        {
            activateRing1.SetActive(true);
            puzzle2.interactable = true;
            path1.SetActive(true);
        }
        if(Progression.levelIndex==2)
        {
            activateRing2.SetActive(true);
            puzzle3.interactable = true;
            path2.SetActive(true);
        }
        if(isPuzzling)
        {
            hintGameObject.SetActive(true);
        }
        else
        {
            hintGameObject.SetActive(false);
        }
    }

    // Function called after a particular puzzle is solved 
    void AfterSolve()
    {
        if(PiecesScript.remaining <= 0 && !isPuzzleSolved)
        {
            parentPuzzle.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            textPanel.gameObject.SetActive(true);
            ScoreManager.scores.Add(Mathf.Ceil(timeBar.fillAmount*totTime));
            Progression.levelIndex++;
            Progression.Instance.sfxAudio.PlayOneShot(solvedAudio);
            isPuzzling = false;
            StartCoroutine(GetBackToTitleScreen(10));
            isPuzzleSolved=!isPuzzleSolved;
        }
        if(parentPuzzle.transform.position.y < -50)
        {
            parentPuzzle.gameObject.SetActive(false);
        }
    }

    public void StartedPuzzling()
    {
        isPuzzling = true;
    }

    public void SetTime(float _time)
    {
        totTime = _time;
        timeLeft = totTime;
        timeBarParent.SetActive(true);
    }

    void GravityEffect()
    {
        try{
            foreach (var piece in pieces)
            {
                piece.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
        catch
        {

        }
    }

    public void Help()
    {
        try{
            if(HintCounter.hintsLeft>0)
            {
                int randomValue = Random.Range(0,currentpieces.Count);
                currentpieces[randomValue].GetComponent<PiecesScript>().HelpPlayer();
                currentpieces.Remove(currentpieces[randomValue]);
                HintCounter.hintsLeft--;
            }
        }
        catch{

        }
    }

    void UpdateTime()
    {
        Color currentColor = timeBar.color;
        timeLeft-=Time.deltaTime;
        Mathf.Clamp(timeLeft,0,totTime);
        currentColor.g = timeLeft/totTime;
        currentColor.r = 1 - timeLeft/totTime;
        timeBar.color = currentColor;
        timeBar.fillAmount = timeLeft/totTime;
        if(timeBar.fillAmount <= 0)
        {
            GravityEffect();
            StartCoroutine(GetBackToTitleScreen(3));
            Progression.Instance.sfxAudio.PlayOneShot(DisassembleAudio);
            isPuzzling = false;
        }
    }

    IEnumerator GetBackToTitleScreen(float time_)
    {
        yield return new WaitForSeconds(time_);
        buttonManagerScript.PuzzleSelect();
    }
}
