using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object6Controller : MonoBehaviour
{
    public GameObject bullet;
    public float attackCooldown;
    private float attackTime;
    public int ATK;
    public int difficulty;

    private void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
    }

    private void Update()
    {
        if (attackTime <= Time.time)
        {
            GameObject bulletInstance = Instantiate(bullet, transform);
            bulletInstance.GetComponent<SnowBulletController>().ATK = difficulty*ATK;
            AudioManager.Play("firepea");
            attackTime = Time.time + attackCooldown;
        }
    }
}
