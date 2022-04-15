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

public class circle : MonoBehaviour 
{
    MoveSpeed moveSpeed;
    public Direction circleDt;
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

    
    
}