using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

//create the constants for all the directions with Enumerations
public enum Direction
{
    isUp,
    isDown,
    isRight,
    isLeft,
    isHorizontal,
    isVertical  
};

public class Circle : MonoBehaviour 
{
    // atributes necessarys for the game
    MoveSpeed moveSpeed;
    public direction circleDt;
    GameStartUI start;
    CircleMove inGame;
    Menu Stop;

    // End game
    public bool isEnd;

    // declaring game objects
    public GameObject LineCircle;
    public GameObject purpleCircle;
    public GameObject pinkCircle;

    trigger CircleAround;

    // collision stuff
    public bool isOne;
    bool isChange;
    bool isFirst;
    float CollisionRunningTime;

    Vector2 prevPos;

    // reference for speed and radius
    [Header("speed,radius")]
    //speed
    public float speed;
    //radius
    [SerializeField][Range(0f,10f)] public float radius;

    public float runningTime = 0;
    // new position
    float x;
    float y;
    private Vector2 newPos = new Vector2();
    //timings

    float nowTime;
    float prevTime;

    void Start() 
    {
        //start direction
        circleDt = direction.isLeft;

        // finds the GameObject and returns it
        moveSpeed = GameObject.Find("GameManager").GetComponent<MoveSpeed>();

        Stop = GameObject.Find("Menu").GetComponent<Menu>();

        start = GameObject.Find("Manager").GetComponent<GameStartUI>();

        inGame = GameObject.Find("circle").GetComponent<CircleMove>();

        LineCircle = GameObject.Find("LinerCircle");
        purpleCircle = GameObject.Find("PurpleCircle");
        pinkCircle = GameObject.Find("PinkCircle");

        //states
        isChange = false;
        isFirst = true;

        isOne = false;
        isEnd = false;

        //circles statements

        speed = moveSpeed.speed;
        LineCircle.OnTransformChildrenChangedAsObservable.GetChild(1).gameObject.SetActive(false);
        radius = 0.75f;

        this.UpdateAsObservable().Subscribe(_ =>
        {
            if (start.isGameStart)
            {
                if (Stop.isClick == false)
                {
                    if (inGame.isUpdate)
                    {
                        if (LineCircle.transform.position == purpleCircle.transform.position)
                        {
                            CircleAround = GameObject.Find("PinkCircle").GetComponent<trigger>();
                        }
                        else if (LineCircle.OnTransformChildrenChangedAsObservable.position == pinkCircle.transform.position)
                        {
                            // ! CHECK IF THE FIND IS PINK CIRCLE OR PURPLE CIRCLE 
                            CircleAround = GameObject.Find("PinkCircle").GetComponent<trigger>();
                        }

                        // speed with time
                        runningTime += Time.deltaTime * speed;

                        if (CircleAround.Change == false)
                        {
                            x = radius *Mathf.Sin((90 * (Mathf.PI / 180)) + runningTime);

                            y = radius * Mathf.Cos((90 * (Mathf.PI / 180)) + runningTime);
                        }
                        else
                        {
                            x = radius * Mathf.Cos(runningTime);
                            y = radius * Mathf.Sin(runningTime);
                        }

                        //newPosition for the object
                        newPos = new Vector2(-x + LineCircle.transform.position.x, -y + LineCircle.transform.position.y);

                        //conditions for the circles

                        if (isFirst)
                        {
                            prevPos = newPos;
                            isFirst = false;
                        }

                        if (!inGame.isFinish)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                isChange = true;
                                isFirst = true;
                            }
                        }

                        if (LineCircle.transform.position == pinkCircle.transform.position && isChange == false)
                        {
                            purpleCircle.transform.position = newPos;
                        }
                        else if (LineCircle.transform.position == purpleCircle.transform.position && isChange == false)
                        {
                            pinkCircle.transform.position = newPos;
                        }

                        if (LineCircle.transform.position == pinkCircle.tranform.position && isChange)
                        {
                            switch (circleDt)
                            {
                                case Direction.isDown:
                                    runningTime = 1.55f;
                                    CollisionRunningTime = 7.75f;
                                    break;
                                case Direction.isUp:
                                    runningTime = 4.65f;
                                    CollisionRunningTime = 10.85f;
                                    break;
                                case Direction.isLeft:
                                    runningTime = 0f;
                                    CollisionRunningTime = 6.2f;
                                    break;
                                case Direction.isRight:
                                    runningTime = 3.1f;
                                    CollisionRunningTime = 9.3f;
                                    break;
                            }
                            isChange = false;
                        }
                        else if (LineCircle.transform.position == purpleCircle.transform.position && isChange)
                        {
                            switch (circleDt)
                            {
                                case Direction.isDown:
                                    runningTime = 1.55f;
                                    CollisionRunningTime = 7.75f;
                                    break;
                                case Direction.isUp:
                                    runningTime = 4.65f;
                                    CollisionRunningTime = 10.85f;
                                    break;
                                case Direction.isLeft:
                                    runningTime = 0f;
                                    CollisionRunningTime = 6.2f;
                                    break;
                                case Direction.isRight:
                                    runningTime = 3.1f;
                                    CollisionRunningTime = 9.3f;
                                    break;
                            }
                            isChange = false;
                        }

                        // condition for game finished
                        if (inGame.isFinish != true)
                        {
                            if (runningTime >= CollisionRunningTime)
                            {
                                inGame.isUpdate = false;
                            }
                        }
                    }

                    // conditions if inGame is not update
                    if (inGame.isUpdate == false)
                    {
                        if (LineCircle.transform.position == pinkCircle.transform.position)
                        {
                            CircleAround = GameObject.Find("PurpleCircle").GetComponent<trigger>();
                        }
                        else if (LineCircle.transform.position == purpleCircle.transform.position)
                        {
                            CircleAround = GameObject.Find("PinkCircle").GetComponent<trigger>();
                        }

                        radius -= 0.08f;
                        if (radius <= 0.0f)
                        {
                            radius = 0.0f;
                        }

                        runningTime += Time.deltaTime * speed;

                        if (CircleAround.Change == false)
                        {
                            x = radius * Mathf.Sin((90 * (Mathf.PI / 180)) + runningTime);
                            y = radius * Mathf.Cos((90 * (Mathf.PI / 180)) + runningTime);
                        }
                        else
                        {
                            x = radius * Mathf.Cos(runningTime);
                            y = radius * Mathf.Sin(runningTime);
                        }

                        //newPosition for the object
                        newPos = new Vector2(-x + LineCircle.transform.position.x, -y + LineCircle.transform.position.y);

                        if (radius > 0.0f)
                        {
                            if (LineCircle.transform.position == pinkCircle.tranform.position && isChange == false)
                            {
                                purpleCircle.transform.position = newPos;
                            }
                            else if (LineCircle.transform.position == purpleCircle.transform.position && isChange == false)
                            {
                                pinkCircle.transform.position = newPos;
                            }
                        }
                        else
                        {
                            if (LineCircle.transform.childCount > 1)
                            {
                                LineCircle.transform.GetChild(1).gameObject.SetActive(true);
                            }
                            else
                            {
                                isEnd = true;
                            }
                        }
                    }
                }
            }
        });  
    }

    // changes the speed when start the game and in the end slow down
    // *** check if the values are correct in all of the songs
    public void SpeedUp()
    {
        if (start.isGameStart)
        {
            speed += 0.1f;
        }
    }
    public void SpeedDown()
    {
        if (start.isGameStart)
        {
            speed -= 0.1f;
        }
    }
}