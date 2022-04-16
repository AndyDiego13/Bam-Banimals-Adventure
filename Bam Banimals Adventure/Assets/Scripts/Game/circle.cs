using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

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
    MoveSpeed moveSpeed;
    public direction circleDt;
    GameStartUI start;
    CircleMove inGame;
    Menu Stop;

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
    float x;
    float y;
    private Vector2 newPos = new Vector2();

    float nowTime;
    float prevTime;

    void Start() 
    {
        circleDt = direction.isLeft;
        moveSpeed = GameObject.Find("GameManager").GetComponent<MoveSpeed>();

        Stop = GameObject.Find("Menu").GetComponent<Menu>();

        start = GameObject.Find("Manager").GetComponent<GameStartUI>();

        inGame = GameObject.Find("circle").GetComponent<CircleMove>();

        LineCircle = GameObject.Find("LinerCircle");
        purpleCircle = GameObject.Find("PurpleCircle");
        
    }
    
}