using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.Rendering;
using DG.Tweening;

public class PiecesScript : MonoBehaviour
{

    public GameManagerScript gameManagerScript;
    private Vector3 rightPosition;
    public bool inRightPosition;
    public bool taken = false;
    Rigidbody2D rb;
    [SerializeField]
    public static int remaining = 36;
    [SerializeField] AudioClip placeAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(0.5f,1.5f);
        transform.position = new Vector3(Random.Range(5f,11f),Random.Range(5.5f,-2f));
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,rightPosition) < 0.1f)
        {
            if(!inRightPosition)
            {
                transform.position = rightPosition;
                inRightPosition = true;
                this.GetComponent<SortingGroup>().sortingOrder = 0;
            }  
        }
        if(inRightPosition && !taken)
        {
            remaining--;
            taken = true;
            Progression.Instance.sfxAudio.PlayOneShot(placeAudio);
            GameManagerScript.currentpieces.Remove(this.gameObject);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HelpPlayer();
        }
        // Not working
        
    }

    public void HelpPlayer()
    {
        transform.DOMove(rightPosition,3,false);
    }
}
