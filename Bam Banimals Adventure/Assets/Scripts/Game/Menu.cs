using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour 
{
    GameStartUI music;
    public Canvas menu;
    public Canvas Game;
    public Text text;

    public bool isClick;
    public bool UiButton;

    float timer;
    int nums;

    void Start() 
    {
        Game = GameObject.Find("Canvas").GetComponent<Canvas>();
        menu = GameObject.Find("Menu").GetComponent<Canvas>();
        text = GameObject.Find("logo").GetComponent<Text>();
        music = GameObject.Find("Manager").GetComponent<GameStartUI>();

        isClick = false;
        menu.enabled = false;
        Game.enabled = true;
        text.enabled = false;
        UiButton = false;        
    }

    void Update() 
    {
        if (text.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                timer = 0;
                text.enabled = false;
            }
        }
    }

    public void play()
    {
        isClick = false;
        Game.enabled = true;
        menu.enabled = false;
        SoundManager.Instance.PlayMusic(music.music);
    }

    public void prev()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        if (i == 1 || i == 8 || i == 12)
        {
            text.enabled = true;
            if (i == 1)
            {
                nums = 1;
            }
            if (i == 8)
            {
                nums = 2;
            }
            if (i == 12)
            {
                nums = 3;
            }

            text.text = nums + "Esta es la primera etapa";
        }
        else
        {
            SoundManager.Instance.Stop();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    public void exit()
    {
        SoundManager.Instance.Stop();
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        UiButton = true;

        if (music.isStart)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                if (!isClick)
                {
                    isClick = true;
                    Game.enabled = false;
                    menu.enabled = true;
                    SoundManager.Instance.Pause();
                }
                else
                {
                    isClick = false;
                    Game.enabled = true;
                    menu.enabled = false;
                    SoundManager.Instance.PlayMusic(music.music);
                }
                
            }
        }
    }
}