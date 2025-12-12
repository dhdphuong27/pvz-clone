using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;
    public static GameController instance;
    public float sunRegen;
    public float baseRegen;
    public float sun;
    private float elapsed;
    public Text text;
    public string map;

    void Awake(){
        instance = this;
        this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("volume")/10f;
    }
    void Start()
    {
        baseRegen = 5/1;
        sun = 50;
        elapsed = 0f;
        GameObject.Find("PlayerName").GetComponent<Text>().text = PlayerPrefs.GetString("user1name") + "'s house";
    }
    public void stopRegen()
    {
        baseRegen = 0;
    }
    void Update()
    {   
        elapsed += Time.deltaTime;
        sunRegen = baseRegen + (baseRegen*GameObject.FindGameObjectsWithTag("Sunflower").Length);
        if (elapsed>=1f){
            elapsed = elapsed % 1f;
            sun = sun + sunRegen*Time.timeScale;
            text.GetComponent<UnityEngine.UI.Text>().text = sun.ToString();
        }
    }

    public void PlaceObject()
    {
        string objName = draggingObject.GetComponent<ObjectDragging>().card.object_game.name;
        if (currentContainer != null && currentContainer.GetComponent<ObjectContainer>().isFull == false)
        {
            if (objName == "Object1" && sun >= 50)
            {
                sun = sun - 50;
                Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                AudioManager.Play("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object2" && sun >= 100)
            {
                sun = sun - 100;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                AudioManager.Play("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object3" && sun >= 50)
            {
                sun = sun - 50;
                Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                AudioManager.Play("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object4" && sun >= 200)
            {
                sun = sun - 200;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                AudioManager.Play("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object5" && sun >= 175)
            {
                sun = sun - 175;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                AudioManager.Play("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object6" && sun >= 175)
            {
                sun = sun - 175;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                AudioManager.Play("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            else if (objName == "Object7" && sun >= 100)
            {
                sun = sun - 100;
                GameObject objectGame = Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
                AudioManager.Play("plant");
                currentContainer.GetComponent<ObjectContainer>().isFull = true;
            }
            //Not enough sun
            else
            {
                StartCoroutine(NotEnoughSun());
            }
            text.GetComponent<UnityEngine.UI.Text>().text = sun.ToString();
        }
        else if (currentContainer != null && currentContainer.GetComponent<ObjectContainer>().isFull == true
                         && objName == "Shovel")
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = false;
        }
    }
    IEnumerator NotEnoughSun()
    {
        text.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        AudioManager.Play("notenoughsun");
        yield return new WaitForSeconds(1);
        text.GetComponent<UnityEngine.UI.Text>().color = Color.white;
    }
    public void DestroyAllZombies()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombie in zombies)
        {
            zombie.GetComponent<ZombieController>().ReceiveDamage(99999);
        }
        AudioManager.Play("explosionnnnnn");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
