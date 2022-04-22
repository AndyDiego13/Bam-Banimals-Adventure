using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour 
{
    trigger setting;
    Circle CircleAround;
    MakeList tiles;
    Menu Stop;
    GameStartUI start;

    public GameObject uncorrectPreFab;
    public GameObject CircleS;
    public GameObject LineCircle;
    public GameObject purpleCircle;
    public GameObject pinkCircle;
    public GameObject End;
    public GameObject effectPreFab;
    public GameObject Point;
    public GameObject CirclePoint;
    public GameObject  moveLine; //previous place
    GameObject child;
    GameObject newEffect;
    GameObject UncorrectObj;

    public List<GameObject> effectList;
    public bool isMove;
    public bool isClick; //for now then is gonna be a key
    public bool isFinish;
    public bool isUpdate;
    public bool isOne;
    public bool isRetire;

    Transform effectHolder;

    Vector3 prevPosition;
    Vector3 targetPosition;

    float distance;

    public int moveCount;
    int childCount;
    int num;

    public void Start() 
    {
        CircleAround = GameObject.Find("circle").GetComponent<Circle>();
        CirclePoint = GameObject.Find("Point");
        start = GameObject.Find("Manager").GetComponent<GameStartUI>();
        tiles = GameObject.Find("Menu").GetComponent<MakeList>();
        Stop = GameObject.Find("Menu").GetComponent<Menu>();
        LineCircle = GameObject.Find("LinerCircle");
        purpleCircle = GameObject.Find("PurpleCircle");
        pinkCircle = GameObject.Find("PinkCircle");
        CircleS = GameObject.Find("circle");
        End = GameObject.Find("EndPoint");
        Point = GameObject.Find("PointCamera");
        effectList = new List<GameObject>();

        isMove = false;
        isUpdate = true;
        isRetire = true;
        isFinish = false;
        isOne = false;
        moveCount = 0;

        string holderName = "Effect";
        effectHolder = new GameObject(holderName).transform;
        effectHolder.parent = transform;

        if (LineCircle.transform.position == pinkCircle.transform.position)
        {
            prevPosition = purpleCircle.transform.position;
            distance = pinkCircle.transform.position.x - purpleCircle.transform.position.x;
        }
        else if (LineCircle.transform.position == purpleCircle.transform.position)
        {
            prevPosition = pinkCircle.transform.position;
            distance = purpleCircle.transform.position.x - pinkCircle.transform.position.x;
        }

        newEffect = Instantiate(effectPreFab) as GameObject;
        newEffect.transform.position = LineCircle.transform.position;
        newEffect.name = "Effect" + num;
        newEffect.transform.parent = effectHolder;
        num += 1;
        effectList.Add(newEffect);
        End.GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update() 
    {
        if (start.isGameStart)
        {
            if (Stop.isClick == false)
            {
                if (isUpdate)
                {
                    moveLine = LineCircle;
                    if (moveCount + 1 < tiles.map.Count)
                    {
                        if (!isFinish)
                        {
                            tiles.map[moveCount].GetComponent<BoxCollider2D>().enabled = false;

                            if (tiles.map[moveCount].transform.childCount != 0)
                            {
                                tiles.map[moveCount].GetComponentInChildren<BoxCollider2D>().enabled = false;
                            }

                            tiles.map[moveCount].GetComponent<BoxCollider2D>().enabled = true;

                            if (tiles.map[moveCount + 1].GetComponent<BoxCollider2D>().enabled == true)
                            {
                                if (tiles.map[moveCount + 1].transform.childCount == 1)
                                {
                                    child = tiles.map[moveCount + 1].transform.GetChild(0).gameObject;
                                    child.GetComponent<BoxCollider2D>().enabled = true;
                                }
                            }

                            if (tiles.map[tiles.count - 1].GetComponent<BoxCollider2D>().enabled == true)
                            {
                                End.GetComponent<BoxCollider2D>().enabled = true;
                            }
                        }
                    }

                    if (LineCircle.transform.position == pinkCircle.transform.position)
                    {
                        setting = GameObject.Find("PinkCircle").GetComponent<trigger>();
                    }
                    else if (LineCircle.transform.position == purpleCircle.transform.position)
                    {
                        setting = GameObject.Find("PinkCircle").GetComponent<trigger>();
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (isMove == true && isFinish == false)
                        {
                            move();
                            moveCount += 1;

                            newEffect = Instantiate(effectPreFab) as GameObject;
                            newEffect.transform.position = LineCircle.transform.position;

                            newEffect.name = "Effect" + num;
                            newEffect.transform.parent = effectHolder;
                            num += 1;

                            effectList.Add(newEffect);
                            Point.transform.position = LineCircle.transform.position;
                        }

                        if (isMove == false)
                        {
                            isUpdate = false;

                            if (LineCircle.transform.position == purpleCircle.transform.position)
                            {
                                UncorrectObj = Instantiate(uncorrectPreFab) as GameObject;
                                UncorrectObj.transform.position = pinkCircle.transform.position;
                            }

                            if (LineCircle.transform.position == pinkCircle.transform.position)
                            {
                                UncorrectObj = Instantiate(uncorrectPreFab) as GameObject;
                                UncorrectObj.transform.position = purpleCircle.transform.position;
                            }
                        }

                        if (isFinish == true)
                        {
                            if (isOne == false)
                            {
                                move();

                                newEffect = Instantiate(effectPreFab) as GameObject;
                                newEffect.transform.position = LineCircle.transform.position;

                                newEffect.name = "Effect" + num;
                                newEffect.transform.parent = effectHolder;

                                num += 1;

                                effectList.Add(newEffect);

                                isOne = true;
                            }
                        }
                    }
                }
            }
        }
    }

    public void move()
    {
        //conditionals for movement between circles using pointers
        if (LineCircle.transform.position == purpleCircle.transform.position)
        {
            LineCircle.transform.position = LineCircle.transform.position;
            pinkCircle.transform.position = LineCircle.transform.position;
            CirclePoint.transform.position = purpleCircle.transform.position;
        }
        else if (LineCircle.transform.position == pinkCircle.transform.position)
        {
            LineCircle.transform.position = tiles.map[moveCount + 1].transform.position;

            purpleCircle.transform.position = LineCircle.transform.position;

            CirclePoint.transform.position = pinkCircle.transform.position;
        }

        if (LineCircle.transform.position == pinkCircle.transform.position)
        {
            prevPosition = purpleCircle.transform.position;
        }
        else if (LineCircle.transform.position == purpleCircle.transform.position)
        {
            prevPosition = pinkCircle.transform.position;
        }
    }
}