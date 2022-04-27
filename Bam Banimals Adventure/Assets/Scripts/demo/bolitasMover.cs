using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolitasMover : MonoBehaviour
{
    //public GameObject bubble;
    //public Transform placeToSpawn;
    //public Transform placeOfEnd;

    public float rotationAmmount;
    Vector3 vec;
    Vector3 center;
    float radius;
    float angle;
    //public float speed;
    //float BPM;

    private void Start() 
    {
        center = transform.position;
        //vec = new Vector3(transform.position.x, transform.position.y);
        radius = 2;
        //BPM = BPM / 60;
        //speed = ((2 * (radius * Mathf.PI)* 1/2) / BPM) * 10;

    }
    private void Update() 
    {
        vec.x = radius*Mathf.Cos(angle);
        vec.y = radius *Mathf.Sin(angle);
        transform.position = center + vec;
        angle += rotationAmmount;
    }

        /*StartCoroutine("summonBalls");
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z + (Time.deltaTime * rotationAmmount));
    }

    IEnumerator summonBalls(){
        while (true){
            yield return new WaitForSeconds(2f);
            Debug.Log("summoning bubble");
            summonBubble();
        }
    }

    private void summonBubble(){
        GameObject bubbleGO = Instantiate(bubble, placeToSpawn);
        bubbleGO.GetComponent<burbujaBehaibour>().StartExpedition(placeOfEnd, Time.time + 2);
    }*/
}
