using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSet : MonoBehaviour 
{
    bool isChange;
    bool isSet;
    [SerializeField] private AudioClip Audio;
    
    private void Start() 
    {
        isChange = false;
        SoundManager.Instance.PlayLoopMusic(Audio);
    }

    private void Update() 
    {
        if (isChange)
        {
            if (!isSet)
            {
                SoundManager.Instance.PlayLoopMusic(Audio);
                isChange = false;
            }
        }
        isSet = false;
    }

    //Cambie el valor del volumen a través de la barrita deslizante
    public void SetMusicVolume(float volume)
    {
        isChange = true;
        isSet  = true;
        SoundManager.Instance.Pause();
        SoundManager.Instance.SetMusicVolume(volume);
    }
}