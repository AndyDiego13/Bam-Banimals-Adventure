using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotarBurbujas : MonoBehaviour
{
    // hacer un loop del movimiento de la burbuja principal

    bool pressKey = false;

    public GameObject CirculoRosa;
    public GameObject bubbles;
    /*
    void OnCollisionStay2D(Collision2D other) 
    {
        //GameObject CirculoRosa = other.gameObject;
        GameObject bubbles = other.gameObject;
        if(other.gameObject.CompareTag("bubbles") && Input.GetKey(KeyCode.K))
        {
            Destroy(other.gameObject);
        }
        
    } 
    */
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        GameObject CirculoRosa = other.gameObject;
        if (other.gameObject.CompareTag("bubbles") && pressKey)
        {
            pressKey = true;
        }
        
    }
    

    void Update() 
    {
        if (Input.GetKey(KeyCode.K) && pressKey)
        {
            bum();
        }
        
    }
    void bum()
    {
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        pressKey = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        pressKey = false;   
    }
    

}
