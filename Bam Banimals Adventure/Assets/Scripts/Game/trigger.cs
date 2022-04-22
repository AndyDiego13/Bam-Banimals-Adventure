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

        if (other.gameObject.tag == "changeTop")
        {
            if (circle.LineCircle.transform.position == other.gameObject.transform.position)
            {
                Change = true;
            }
        }

        if (other.gameObject.tag == "changeDown")
        {
            if (circle.LineCircle.transform.position == other.gameObject.transform.position)
            {
                Change = false;
            }
        }

        if (other.gameObject.tag == "End")
        {
            circle.isFinish = true;
        }

        if (other.gameObject.tag == "CurveLd")
        {
            if (tiles.map[tileNum].tag == "Horizontal")
            {
                AroundCircle.circleDT = Direction.isLeft;
            }
            else if (tiles.map[tileNum].tag == "Vertical")
            {
                AroundCircle.circleDt = Direction.isUp;
            }
            else if (tiles.map[tileNum].tag == "CurveLt")
            {
                AroundCircle.circleDt = Direction.isUp;
            }
            else if (tiles.map[tileNum].tag == "CurveRd")
            {
                AroundCircle.circleDt = Direction.isLeft;
            }
            else if (tiles.map[tileNum].tag == "CurveRt")
            {
                AroundCircle.circleDt = Direction.isLeft;
            }
        }
        
        if (other.gameObject.tag == "CurveLt")
        {
            if (tiles.map[tileNum].tag == "Horizontal")
            {
                AroundCircle.circleDt = Direction.isLeft;
            }
            else if (tiles.map[tileNum].tag == "Vertical")
            {
                AroundCircle.circleDt = Direction.isDown;
            }
            else if (tiles.map[tileNum].tag == "CurveLd")
            {
                AroundCircle.circleDt = Direction.isDown;
            }
            else if (tiles.map[tileNum].tag == "CurveRt")
            {
                AroundCircle.circleDt = Direction.isLeft;
            }
            else if (tiles.map[tileNum].tag == "CurveRd")
            {
                AroundCircle.circleDt = Direction.isLeft;
            }
        }

        if (other.gameObject.tag == "CurveRd")
        {
            if (tiles.map[tileNum].tag == "Horizontal")
            {
                AroundCircle.circleDt = Direction.isRight;
            }
            else if (tiles.map[tileNum].tag == "Vertical")
            {
                AroundCircle.circleDt = Direction.isUp;
            }
            else if (tiles.map[tileNum].tag == "CurveLd")
            {
                AroundCircle.circleDt = Direction.isRight;
            }
            else if (tiles.map[tileNum].tag == "CurveLt")
            {
                if (tiles.map[tileNum].transform.position.y < tiles.map[tileNum + 1].transform.position.y - 0.8f)
                {
                    AroundCircle.circleDt = Direction.isUp;
                }
                else
                {
                    AroundCircle.circleDt = Direction.isRight;
                }
            }
            else if (tiles.map[tileNum].tag == "CurveRt")
            {
                AroundCircle.circleDt = Direction.isUp;
            }
        }

        if (other.gameObject.tag == "CurveRt")
        {
            if (tiles.map[tileNum].tag == "Horizontal")
            {
                AroundCircle.circleDt = Direction.isRight;
            }
            else if (tiles.map[tileNum].tag == "Vertical")
            {
                AroundCircle.circleDt = Direction.isDown;
            }
            else if (tiles.map[tileNum].tag == "CurveLd")
            {
                if (tiles.map[tileNum].transform.position.y > tiles.map[tileNum + 1].transform.position.y)
                {
                    AroundCircle.circleDT = Direction.isDown;
                }
                else
                {
                    AroundCircle.circleDT = Direction.isRight;
                }
            }
            else if (tiles.map[tileNum].tag == "CurveLt")
            {
                AroundCircle.circleDT = Direction.isRight;
            }
            else if (tiles.map[tileNum].tag == "CurveRd")
            {
                AroundCircle.circleDT = Direction.isDown;
            }
        }

        if (other.gameObject.tag == "Vertical")
        {
            if (tiles.map[tileNum].tag == "CurveLd")
            {
                AroundCircle.circleDT = Direction.isDown;
            }
            else if (tiles.map[tileNum].tag == "CurveLt")
            {
                AroundCircle.circleDT = Direction.isUp;
            }
            else if (tiles.map[tileNum].tag == "CurveRd")
            {
                AroundCircle.circleDT = Direction.isDown;
            }
            else if (tiles.map[tileNum].tag == "CurveRt")
            {
                AroundCircle.circleDT = Direction.isUp;
            }
        }

        if (other.gameObject.tag == "Horizontal")
        {
            if (tiles.map[tileNum].tag == "CurveLd")
            {
                AroundCircle.circleDT = Direction.isRight;
            }
            else if (tiles.map[tileNum].tag == "CurveLt")
            {
                AroundCircle.circleDT = Direction.isRight;
            }
            else if (tiles.map[tileNum].tag == "CurveRd")
            {
                AroundCircle.circleDT = Direction.isLeft;
            }
            else if (tiles.map[tileNum].tag == "CurveRt")
            {
                AroundCircle.circleDT = Direction.isLeft;
            }
        }

        tile = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        circle.isMove = false;
        tile = null;
    }
}