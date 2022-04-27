using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotarBurbujas : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D other) 
    {
        GameObject CirculoRosa = other.gameObject;
        if (other.gameObject.tag == "bubbles")
        {
            Destroy(other.gameObject);
        }
        
    }

}
