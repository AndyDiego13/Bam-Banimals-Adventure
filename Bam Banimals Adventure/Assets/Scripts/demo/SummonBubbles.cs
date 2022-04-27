using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBubbles : MonoBehaviour
{
    public GameObject bubbles;
    public Transform placeToSpawn;
    public Transform placeToEnd;
    private void Start() 
    {
        StartCoroutine("summonBubbles");   
    }

    IEnumerator summonBubbles()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Debug.Log("summoning bubble");
            summonBubble();
        }
    }

    private void summonBubble()
    {
        //GameObject bubbleGo = Instantiate(bubbles, placeToSpawn);
        //bubbleGo.GetComponent<burbujaBehaibour>().StartExpedition(placeToEnd, Time.time + 2);
    }
}
