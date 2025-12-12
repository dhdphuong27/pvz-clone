using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieController : MonoBehaviour
{

    public int HP;
    public int ATK;
    public float movementSpeed;
    public float baseMovementSpeed;
    public float attackCooldown;
    public bool isStopped;
    public string map;
    public int difficulty;

    private void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
    }
    void Update()
    {
        if (!isStopped)
        {
            //transform.Translate(new Vector3(movementSpeed*-1,0,0));
            Vector3 newPosition = transform.position;
            newPosition.x -= movementSpeed*Time.timeScale*Time.deltaTime*500;
            transform.position = newPosition;
        }
        if (transform.position.x<450)
        {
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            foreach (GameObject zombie in zombies)
            {
                zombie.GetComponent<ZombieController>().isStopped=true;
            }
            ZombiesSpawner spawner = FindObjectOfType<ZombiesSpawner>();
            if (spawner != null) spawner.stopSpawning();
            if (GameController.instance != null) GameController.instance.stopRegen();
            if (ResultController.instance != null) ResultController.instance.ZombiesWin();
            Destroy(this.gameObject);
        }   
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            StartCoroutine(Attack(collision));
            isStopped = true;
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        if (collision == null)
        {
            isStopped = false;
        }
        else if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<HPController>().ReceiveDamage(ATK*difficulty);
            AudioManager.Play("chomp");
            yield return new WaitForSeconds(attackCooldown);
            StartCoroutine(Attack(collision));
        }
    }
    public void ReceiveDamage(int DMG)
    {
        if (HP - DMG <= 0)
        {
            transform.parent.GetComponent<SpawnPoint>().zombies.Remove(this.gameObject);
            Destroy(this.gameObject);
            ZombiesSpawner zs = FindObjectOfType<ZombiesSpawner>();
            if (zs != null) zs.ZombieKilled();
            AudioManager.Play("zombiedie");
        }
        else
        {
            HP = HP - DMG;
        }
    }
    public void Slow()
    {
        movementSpeed = baseMovementSpeed/2;
    }
}
