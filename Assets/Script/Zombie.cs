using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Zombie 
{
    public float spawnTime;
    public ZombieType zombieType; 
    public int spawner;
    public bool randomSpawn;
    public bool isSpawned;
}
public enum ZombieType 
{
    Zombie1, 
    Zombie2, 
    Zombie3
}
