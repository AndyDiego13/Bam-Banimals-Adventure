using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolitasMover : MonoBehaviour
{
    public GameObject bubble;
    public Transform placeToSpawn;
    public Transform placeOfEnd;

    public float rotationAmmount;

    private void Start() {
        StartCoroutine("summonBalls");
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
    }
}
