using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour 
{
    CircleMove circle;
    GameStartUI start;
    GameObject tileAttribute;
    GameObject LineCircle;
    MakeList tiles;

    int countCr;
    bool isRotationUp;
    bool isRotationDown;
    bool isRotationRight;
    bool isRotationLeft;
    float speed;

    private void Start() 
    {
        circle = GameObject.Find("circle").GetComponent<CircleMove>();
        LineCircle = GameObject.Find("LinerCircle");
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();
        start = GameObject.Find("Manager").GetComponent<GameStartUI>();

        countCr = 0;
        speed = 0.4f;
    }

    private void Update() 
    {
        if (start.isGameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                countCr += 1;
            }
        }

        if (!circle.isFinish)
        {
            if (tiles.map[countCr].transform.childCount != 0)
            {
                tileAttribute = tiles.map[countCr].transform.GetChild(0).gameObject;
            }
        }
        // RotateDown, RotateTop, RotateLeft, RotateRight
        if (tileAttribute != null)
        {
            if (LineCircle.transform.position == tileAttribute.transform.position)
            {
                if (tileAttribute.tag == "RotateDown")
                {
                    isRotationDown = true;
                }
                if (tileAttribute.tag == "RotateTop")
                {
                    isRotationUp = true;
                }
                if (tileAttribute.tag == "RotateLeft")
                {
                    isRotationLeft = true;
                }
                if (tileAttribute.tag == "RotateRight")
                {
                    isRotationRight = true;
                }
            }

            if (isRotationUp)
            {
                if (this.transform.eulerAngles.z >= 90.0f)
                {
                    isRotationUp = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 90f);
                }               
            }

            if (isRotationDown)
            {
                if (this.transform.eulerAngles.z >= 270.0f)
                {
                    isRotationDown = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 270.0f);
                }
            }

            if (isRotationLeft)
            {
                if (this.transform.eulerAngles.z >= 180.0f)
                {
                    isRotationLeft = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 180.0f);
                }
            }

             if (isRotationRight)
            {
                if (this.transform.eulerAngles.z >= 0.0f)
                {
                    isRotationRight = false;
                }
                else
                {
                    this.transform.Rotate(Vector3.forward * Time.deltaTime * speed * 0f);
                }
            }
        }        
    }
}