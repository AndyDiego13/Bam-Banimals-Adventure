using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numOfBubbles;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}
public class WaveSpawn : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;
}
