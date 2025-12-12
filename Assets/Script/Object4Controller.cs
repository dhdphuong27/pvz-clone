using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object4Controller : MonoBehaviour
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
            StartCoroutine(Attack());
            attackTime = Time.time + attackCooldown;
        }
    }
    IEnumerator Attack()
    {
        GameObject bulletInstance1 = Instantiate(bullet, transform);
        AudioManager.Play("firepea");
        bulletInstance1.GetComponent<BulletController>().ATK = difficulty*ATK;
        yield return new WaitForSeconds(1/10F);
        GameObject bulletInstance2 = Instantiate(bullet, transform);
        AudioManager.Play("firepea");
        bulletInstance2.GetComponent<BulletController>().ATK = difficulty*ATK;
        
    }
}
