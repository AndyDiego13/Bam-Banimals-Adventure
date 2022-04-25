using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Transform ICE_Transform, FIRE_Transform;
    public Transform CurrentRotatePlanetTransform, DifferentPlanetTransform;
    [SerializeField] private GameObject ICE_GameObject, FIRE_GameObejct;
    [SerializeField] private Sprite RedOrbit, BlueOrbit;
    [SerializeField] private float RotateSpeed = 3.0f;
    [SerializeField] private Vector3 RotateDirection = Vector3.back;

    private void Awake()
    {
        CurrentRotatePlanetTransform = ICE_Transform;
        ICE_GameObject.tag = "AroundPlanet";
        DifferentPlanetTransform = FIRE_Transform;
    }

    void Update()
    {
        MovePlanet();
        RotatePlanet();
    }

    void RotatePlanet()
    {
        CurrentRotatePlanetTransform.RotateAround(DifferentPlanetTransform.position, RotateDirection, RotateSpeed * Time.deltaTime);
    }

    void MovePlanet()
    {
        if(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            Transform Temp = CurrentRotatePlanetTransform;
            CurrentRotatePlanetTransform = DifferentPlanetTransform;
            DifferentPlanetTransform = Temp;
        }
    }

    /*
    void ShowOrbit()
    {

    }
    */
}