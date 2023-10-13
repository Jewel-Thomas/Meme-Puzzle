using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    // public GameObject correctForm;
    public static float clampVal;
    public static float y_clampVal;
    private bool moving;
    private float startPosX;
    private float startPosY;
    int OIL = 1;

    // public GameObject selectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(moving && !this.GetComponent<PiecesScript>().inRightPosition)
        {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.x = Mathf.Clamp(mousePos.x,-5.5f,clampVal);
                mousePos.y = Mathf.Clamp(mousePos.y,-y_clampVal/2-0.5f,y_clampVal);
                this.GetComponent<SortingGroup>().sortingOrder = OIL;
                OIL++;

                this.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY,this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        startPosX = mousePos.x - this.transform.localPosition.x;
        startPosY = mousePos.y - this.transform.localPosition.y;

        moving  = true;
    }

    private void OnMouseUp()
    {
        moving = false;
    }

}
