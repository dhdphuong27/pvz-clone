using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowBulletController : MonoBehaviour
{
    public float movementSpeed;
    public int ATK;
    public int difficulty;

    private void Start()
    {
        difficulty = PlayerPrefs.GetInt("difficulty");
    }

    void Update()
    {
        //transform.Translate(new Vector3(movementSpeed,0,0));
        Vector3 newPosition = transform.position;
        newPosition.x += movementSpeed*Time.timeScale*Time.deltaTime*500;
        transform.position = newPosition;
        if (transform.position.x>2000)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            if (collision.gameObject.name == "Zombie1(Clone)")
            {
                AudioManager.Play("zombie1hit");
            }
            else if (collision.gameObject.name == "Zombie2(Clone)")
            {
                AudioManager.Play("zombie2hit");
            }
            else if (collision.gameObject.name == "Zombie3(Clone)")
            {
                AudioManager.Play("zombie3hit");
            }
            collision.gameObject.GetComponent<ZombieController>().ReceiveDamage(difficulty*ATK);
            collision.gameObject.GetComponent<ZombieController>().Slow();
            Destroy(this.gameObject);
        }
        
    }
    
}
