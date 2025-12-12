using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZombiesSpawner : MonoBehaviour
{
    public List<GameObject> zombiesPrefabs;
    public List<Zombie> zombies;
    public int deadZombie;
    private float secondPassed;
    public string map;

    private void Update()
    {
        secondPassed += Time.deltaTime;
        foreach (Zombie zombie in zombies)
        {
            if (zombie.isSpawned == false && zombie.spawnTime <= secondPassed)
            {
                if (zombie.randomSpawn)
                {
                    zombie.spawner = Random.Range(0, transform.childCount);
                }
                GameObject zombieInstance = Instantiate(zombiesPrefabs[(int)zombie.zombieType], transform.GetChild(zombie.spawner).transform);
                transform.GetChild(zombie.spawner).GetComponent<SpawnPoint>().zombies.Add(zombieInstance);
                zombie.isSpawned = true;
            }
        }
        if (deadZombie==zombies.Count)
        {
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                zombie.GetComponent<ZombieController>().isStopped=true;
            }
            stopSpawning();
            GameController.instance.stopRegen();
            ResultController.instance.PlantsWin();
            deadZombie = 0;
        }
    }
    public void stopSpawning()
    {
        foreach (Zombie zombie in zombies)
        {
            zombie.isSpawned = true;
        }
    }
    public void ZombieKilled()
    {
        deadZombie = deadZombie + 1;
    }
}
