using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartUI : MonoBehaviour 
{
    CircleMove inGame;
    Menu Stop;
    Circle CircleAround;
    Text Stage;

    public bool isStart;
    public bool isGameStart;
    public Text start;
    public Text End;
    public AudioClip music;

    bool isMusicOn;
    bool isOne;
    float timer;
    float countGui;
    float percent;

    public void Start() 
    {
        Stage = GameObject.Find("Beach").GetComponent<Text>();
        Stop = GameObject.Find("Menu").GetComponent<Menu>();
        inGame = GameObject.Find("circle").GetComponent<CircleMove>();
        CircleAround = GameObject.Find("circle").GetComponent<Circle>();
        start = GameObject.Find("Text").GetComponent<Text>();
        End = GameObject.Find("End").GetComponent<Text>();

        isStart = false;
        isGameStart = false;
        isOne = true;
        timer = 0.0f;

        //game tags of directions Horizontal, Vertical, CurveLt, CurveLd, CurveRd, CurveRt
        GameObject[] tag = GameObject.FindGameObjectsWithTag("Horizontal");
        GameObject[] tag2 = GameObject.FindGameObjectsWithTag("Vertical");
        GameObject[] tag3 = GameObject.FindGameObjectsWithTag("CurveLt");
        GameObject[] tag4 = GameObject.FindGameObjectsWithTag("CurveLd");
        GameObject[] tag5 = GameObject.FindGameObjectsWithTag("CurveRd");
        GameObject[] tag6 = GameObject.FindGameObjectsWithTag("CurveRt");

        countGui = tag.Length + tag2.Length + tag3.Length + tag4.Length + tag5.Length + tag6.Length;

        End.enabled = false;
    }

    void Update() 
    {
        if (Input.GetMouseButtonDown(0) && isStart == false)
        {
            isStart = true;
        }

        if (isStart && Stop.isClick == false)
        {
            timer += Time.deltaTime;

            if (timer < 1.0f && timer >= 0.0f)
            {
                start.text = "3";
            }

            if (timer < 2.0f && timer >= 1.0f)
            {
                start.text = "2";
            }

            if (timer >= 2.0f && timer <3.0f)
            {
                start.text = "1";
            }

            if (timer >= 3.0f)
            {
                if (isOne)
                {
                    isMusicOn = true;
                    isOne = false;
                }

                start.enabled = false;
                isGameStart = true;
            }

            if (isMusicOn == true)
            {
                SoundManager.Instance.PlayMusic(music);
                isMusicOn = false;
            }
        }

        if (inGame.isUpdate == false)
        {
            SoundManager.Instance.Stop();

            if (CircleAround.isEnd)
            {
                percent = (inGame.moveCount / countGui);
                percent = Mathf.Round(percent * 100);
                End.enabled = true;
                End.text = percent + "% complete";
            }
        }   
    }
}