using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotarBurbujas : MonoBehaviour
{
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
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        GameObject CirculoRosa = other.gameObject;
        if (other.gameObject.CompareTag("bubbles") && pressKey)
        {
            bum();
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
