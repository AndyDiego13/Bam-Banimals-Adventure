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
        
    }
}