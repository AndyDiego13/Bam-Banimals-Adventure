using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burbujaBehaibour : MonoBehaviour
{
    //public float timeOfArrival;
    //Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second
    public float speed = 0.1F;
    // * maybe i can used my speed formula with the bpm

    // Time when the movement started
    private float startTime;
    // * when starts to play the drumset - time to the bubble to arrive to the button

    //total distance between the markers
    private float journeyLength;


    void Start() 
    {
        //keep a note of the time the movement started
        startTime = Time.time;

        //calculate the journey length
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);



    }

    // Move to the target end position
    void Update() 
    {
        // Distance moved equals elapsed time times speed
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance
        float fractionOfJourney = distCovered / journeyLength;

        //Set our position as a fraction of the distance between the markers
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);



        //transform.position = Vector3.MoveTowards(transform.position, goTo.position, (distance));
        //transform.position = Vector2.MoveTowards(startSpawn.position, goTo.position, distance);
        //if (Time.time >= timeOfArrival) {
            //Destroy(gameObject);
       // }


    }

    /*public void StartExpedition(Transform placeToGo, Transform spawn)
    {
        goTo = placeToGo;


        startSpawn = spawn;

        //distance = (timeWhenThere - Time.time) / (goTo.position.y - transform.position.y);
        distance = 1f;
        //timeOfArrival = (timeWhenThere * 10f);

        gameObject.SetActive(true);
    }*/
}
