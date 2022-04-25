using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotarBurbujas : MonoBehaviour
{
    public AudioSource blower;
    public AudioClip note;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "burbujas")
        {
            Destroy(other.gameObject);
            blower.PlayOneShot(note);
        }
    }
}
