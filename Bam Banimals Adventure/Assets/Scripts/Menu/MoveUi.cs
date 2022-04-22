using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveUi : MonoBehaviour 
{
    PlayerMotion circle;
    PlayerCollision position;

    public GameObject StageLogo1;
    public GameObject StageLogo2;
    public GameObject StageLogo3;
    public GameObject LineCircle;
    public GameObject purpleCircle;
    public GameObject pinkCircle;

    GameObject stage1Effect;
    GameObject stage2Effect;
    GameObject stage3Effect;
    GameObject map;

    SpriteRenderer Stage1image;
    SpriteRenderer Stage2image;
    SpriteRenderer Stage3image;

    bool isStage1Up;
    bool isStage2Up;
    bool isStage3Up;
    bool RotationLeft;

    void Start() 
    {
        circle = GameObject.Find("circle").GetComponent<PlayerMotion>();

        Stage1image = GameObject.Find("Stage1Loge").GetComponent<SpriteRenderer>();
        Stage1image = GameObject.Find("Stage2Loge").GetComponent<SpriteRenderer>();
        Stage1image = GameObject.Find("Stage3Loge").GetComponent<SpriteRenderer>();

        LineCircle = GameObject.Find("LinerCircle");
        purpleCircle = GameObject.Find("PurpleCircle");
        pinkCircle = GameObject.Find("PinkCircle");

        StageLogo1 = GameObject.Find("Stage1Loge");
        StageLogo2 = GameObject.Find("Stage2Loge");
        StageLogo3 = GameObject.Find("Stage3Loge");

        map = GameObject.Find("Map");

        stage1Effect = StageLogo1.transform.GetChild(0).gameObject;
        stage2Effect = StageLogo2.transform.GetChild(0).gameObject;
        stage3Effect = StageLogo3.transform.GetChild(0).gameObject;

        
    }



}