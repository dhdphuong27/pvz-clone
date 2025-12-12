using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController: MonoBehaviour
{
    public static ResultController instance;
    public string map;
    public string result = "";
    private float timeCounter = 0;
    public int stage;
    void Update()
    {
        if (result == "pl")
        {
            if (map=="FrontYardDaytime")
            {
                if (PlayerPrefs.GetInt("map1")==stage)
                {
                    PlayerPrefs.SetInt("map1", stage+1);
                }
            }
            if (map=="FrontYardNighttime")
            {
                if (PlayerPrefs.GetInt("map2")==stage)
                {
                    PlayerPrefs.SetInt("map2", stage+1);
                }
            }
            if (map=="MidAutumnNighttime")
            {
                if (PlayerPrefs.GetInt("map3")==stage)
                {
                    PlayerPrefs.SetInt("map3", stage+1);
                }
            }
            timeCounter += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || timeCounter>=10)
            {
                Time.timeScale = 1F;
                SceneManager.LoadScene(map);
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 1F;
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (result == "zb")
        {
            timeCounter += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) || timeCounter>=10)
            {
                Time.timeScale = 1F;
                SceneManager.LoadScene(map);
            }
            else if (Input.GetKey(KeyCode.Return))
            {
                Time.timeScale = 1F;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 1F;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void OnDestroy()
    {
        if (instance == this) instance = null;
    }
    public void PlantsWin()
    {
        AudioManager.Play("winmusic");
        result = "pl";
        StartCoroutine(Navigate("WinScreen"));
    }
    public void ZombiesWin()
    {
        AudioManager.Play("scream");
        result = "zb";
        StartCoroutine(Navigate("LoseScreen"));
    }
    IEnumerator Navigate(string screen)
    {
        yield return new WaitForSeconds(2);
        GameObject.Find(screen).GetComponent<Image>().enabled = true;
        /*yield return new WaitForSeconds(2);
        SceneManager.LoadScene(map);*/
    } 
}
