using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotarBurbujas : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D other) 
    {
       if (other.gameObject.tag == "burbuja" && Input.anyKeyDown)
       {
           Destroy(other.gameObject);
       } 
    }

}
