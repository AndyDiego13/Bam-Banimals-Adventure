using UnityEngine;

public class MakeList : MonoBehaviour 
{
    public int countL;
    public List<GameObject> map;
    GameObject tiles;

    private void Start() 
    {
        GameObject[] tag = GameObject.FindGameObjectsWithTag("Horizontal");
        GameObject[] tag2 = GameObject.FindGameObjectsWithTag("Vertical");
        GameObject[] tag3 = GameObject.FindGameObjectsWithTag("CurveLt");
        GameObject[] tag4 = GameObject.FindGameObjectsWithTag("CurveLd");
        GameObject[] tag5 = GameObject.FindGameObjectsWithTag("CurveRt");
        GameObject[] tag6 = GameObject.FindGameObjectsWithTag("CurveRd");

        countL = tag.Length + tag2.Length + tag3.Length + tag4.Length + tag5.Length + tag6.Length;

        map = new List<GameObject>();

        for (int i = 0; i < countL; i++)
        {
            tiles = GameObject.Find(i.ToString());
        }
    }

    
}