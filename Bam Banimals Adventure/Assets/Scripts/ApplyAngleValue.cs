using UnityEngine;
using UnityEngine.Scene;

public class ApplyAngleValue : MonoBehaviour {
    //Start is called before the first frame update
    void Start() {
        float angle = PlayerPrefs.GetFloat("Angle", 5.0f) *
        transform.rotation = Queaternion.Euler(0,0,angle);
    }
}