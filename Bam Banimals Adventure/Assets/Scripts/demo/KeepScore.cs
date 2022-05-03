using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour
{
    public Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI() 
    {
        GUI.Box(new Rect(100, 100, 100, 100), "Score");
        
    }
}
