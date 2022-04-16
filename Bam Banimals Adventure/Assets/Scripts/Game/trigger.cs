using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class trigger : MonoBehaviour {
    MoveSpeed moveSpeed;
    int tileNum;
    public bool Change;

    public GameObject tile;
    Circle AroundCircle;
    CircleMove circle;
    MakeList tiles;
    public float speed;

    private void Start() 
    {
        moveSpeed = GameObject.Find("GameManager").GetComponent<MoveSpeed>();
        tiles = GameObject.Find("Manager").GetComponent<MakeList>();
        circle = GameObject.Find("circle").GetComponent<CircleMove>();
        AroundCircle = GameObject.Find("circle").GetComponent<Circle>();
        Change = false;
        tileNum = 0;
        speed = moveSpeed.speed;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        circle.isMove = true;

        for (int i = 0; i < tiles.map.Count; i++)
        {
            if (circle.moveDot.transform.position == tiles.map[i].transform.position)
            {
                tileNum = 1;
                break;
            }
        }
        
        if (other.gameObject.tag == "UpSpeed")
        {
            if (circle.LineCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 2.0f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (other.gameObject.tag == "DownSpeed")
        {
            if (circle.LineCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 0.5f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (other.gameObject.tag == "DoubleDownSpeed")
        {
            if (circle.LineCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 0.25f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (other.gameObject.tag == "DoubleUpSpeed")
        {
            if (circle.LineCircle.transform.position == other.gameObject.transform.position)
            {
                AroundCircle.speed = AroundCircle.speed * 4.0f;
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }



    }
}