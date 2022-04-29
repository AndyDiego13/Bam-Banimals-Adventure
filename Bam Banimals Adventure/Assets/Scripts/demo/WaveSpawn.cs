using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numOfBubbles;
}
public class WaveSpawn : MonoBehaviour
{
    [SerializeField] Wave[] waves;
}
