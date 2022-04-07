using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUIAngle : MonoBehaviour {
    [SerializeField] Text display;

    float angle = 0.0f;

    public void ChangeValue(float value)
    {
        angle += value;
        display.text = angle.ToString();
        Player
    }
}