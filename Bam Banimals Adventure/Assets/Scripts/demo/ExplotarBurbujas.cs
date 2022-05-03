using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Events;


public class ExplotarBurbujas : MonoBehaviour
{
    // hacer un loop del movimiento de la burbuja principal

    bool pressKey = false;

    public GameObject CirculoRosa;
    public GameObject bubbles;

    //public Action<Collision2D> OnCollisionEnter2D_Action;
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
    [SerializeField] int points;
    [SerializeField] Text pointsText;
    //[SerializeField] Text gameOver;
    
    void OnCollisionEnter2D(Collision2D other) 
    {   
        
        GameObject CirculoRosa = other.gameObject;
        /*
        if (other.gameObject.CompareTag("bubbles") && pressKey)
        {
            pressKey = true;
        }
        */
        if (other.collider.GetType() == typeof(BoxCollider2D) && other.gameObject.CompareTag("bubbles") && pressKey)
        {
            pressKey = true;
            Debug.Log("perfect");
        }
        else if (other.collider.GetType() == typeof(PolygonCollider2D) && other.gameObject.CompareTag("bubbles") && pressKey)
        {
            pressKey = true;
            Debug.Log("good");

        }
        else if (other.collider.GetType() == typeof(EdgeCollider2D) && other.gameObject.CompareTag("bubbles") && pressKey)
        {
            pressKey = true;
            Debug.Log("bad");
        }
        else
        {
            pressKey = false;
            Debug.Log("miss");
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
        if (other.gameObject.CompareTag("perfect") && pressKey)
        {
            points += 3;
            pointsText.text = "Score: " + points;
        }
        if (other.gameObject.CompareTag("good") && pressKey)
        {
            points += 2;
            pointsText.text = "Score: " + points;
        }
        if (other.gameObject.CompareTag("bad") && pressKey)
        {
            points += 1;
            pointsText.text = "Score: " + points;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        pressKey = false;   
    }
    

}
