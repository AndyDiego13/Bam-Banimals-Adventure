using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burbujaBehaibour : MonoBehaviour
{
    public float timeOfArrival;

    public Transform goTo;

    public float distance;

    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, goTo.position, (distance));

        if (Time.time >= timeOfArrival) {
            Destroy(gameObject);
        }
    }

    public void StartExpedition(Transform placeToGo, float timeWhenThere)
    {
        goTo = placeToGo;

        timeOfArrival = (timeWhenThere * 10f)/2;

        distance = (timeWhenThere - Time.time) / (goTo.position.y - transform.position.y);

        gameObject.SetActive(true);
    }
}
