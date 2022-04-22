using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour 
{
    PlayerMotion circle;
    Camera mainCamera;
    PlayerCollision trigger;
    Vector3 viewCamera;

    public GameObject LineCircle;
    public GameObject purpleCircle;
    public GameObject pinkCircle;

    bool isZoom;
    float timer;

    void Start() 
    {
        circle = GameObject.Find("circle").GetComponent<PlayerMotion>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        LineCircle = GameObject.Find("LinerCircle");
        purpleCircle = GameObject.Find("PurpleCircle");
        pinkCircle = GameObject.Find("PinkCircle");

        timer = 0.0f;
        viewCamera = transform.position;
    }

    void Update() 
    {
        if (LineCircle.transform.position == pinkCircle.transform.position)
        {
            trigger = purpleCircle.GetComponent<PlayerCollision>();
        }
        else if (LineCircle.transform.position == purpleCircle.transform.position)
        {
            trigger = pinkCircle.GetComponent<PlayerCollision>();
        }

        //zoom out-close
        if (trigger.isMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                timer += Time.deltaTime;
                mainCamera.fieldOfView -= 5.0f;
                isZoom = true;
            }
            else
            {
                mainCamera.fieldOfView = 60;
                isZoom = false;
            }
        }
    }
}