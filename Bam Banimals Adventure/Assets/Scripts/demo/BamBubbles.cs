using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamBubbles : MonoBehaviour
{
    
    public GameObject CirculoRosa;
    public AudioSource hitSource;
    bool pressKey = false;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.K) && pressKey)
        {
           hitSource.Play();
            
        }
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        pressKey = true;
    }

    /*IEnumerator Start() 
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = hitSource;
        //audio.Play();
    }*/
}
