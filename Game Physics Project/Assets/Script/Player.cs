using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public float movSpeed = 0f;

    public int points = 0;
    
    void update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movSpeed, Space.World);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movSpeed, Space.World);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fruit")
        {
            points++;
            Destroy(other.gameObject);
        }
    }
}
