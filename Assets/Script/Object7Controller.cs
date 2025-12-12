using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object7Controller : MonoBehaviour
{
    public int ATK;
    public int difficulty;

    private void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            StartCoroutine(Attack(collision));
        }
    }
    IEnumerator Attack(Collider2D collision)
    {
        collision.gameObject.GetComponent<ZombieController>().ReceiveDamage(difficulty*ATK);
        AudioManager.Play("seedlift");
        yield return new WaitForSeconds(1);
        StartCoroutine(Attack(collision));
    }
}
