using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Making lists using tags of the game objects of movements
public class MakeList : MonoBehaviour 
{
    public int count;
    public List<GameObject> map;
    GameObject tiles;

    private void Start() 
    {
        GameObject[] tag = GameObject.FindGameObjectsWithTag("Horizontal");
        GameObject[] tag2 = GameObject.FindGameObjectsWithTag("Vertical");
        GameObject[] tag3 = GameObject.FindGameObjectsWithTag("CurveLt");
        GameObject[] tag4 = GameObject.FindGameObjectsWithTag("CurveLd");
        GameObject[] tag5 = GameObject.FindGameObjectsWithTag("CurveRd");
        GameObject[] tag6 = GameObject.FindGameObjectsWithTag("CurveRt");

        count = tag.Length + tag2.Length + tag3.Length + tag4.Length + tag5.Length + tag6.Length;
        //making new list using tiles
        map = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            tiles = GameObject.Find(i.ToString());
            tiles.GetComponent<BoxCollider2D>().enabled = false;
            map.Add(tiles);
        }
    }

    
}