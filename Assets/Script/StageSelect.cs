using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public void Awake()
    {
        this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("volume")/10f;
    }
    public void Start()
    {
        string mapName = SceneManager.GetActiveScene().name;
        if (mapName == "FrontYardDaytime")
        {
            int mapprogress = PlayerPrefs.GetInt("map1");
            if (mapprogress>=1)   GameObject.Find("Stage1").GetComponent<Button>().interactable = true;
            if (mapprogress>=2)   GameObject.Find("Stage2").GetComponent<Button>().interactable = true;
            if (mapprogress>=3)   GameObject.Find("Stage3").GetComponent<Button>().interactable = true;  
        }
        if (mapName == "FrontYardNighttime")
        {
            int mapprogress = PlayerPrefs.GetInt("map2");
            if (mapprogress>=1)   GameObject.Find("Stage1").GetComponent<Button>().interactable = true;
            if (mapprogress>=2)   GameObject.Find("Stage2").GetComponent<Button>().interactable = true;
            if (mapprogress>=3)   GameObject.Find("Stage3").GetComponent<Button>().interactable = true;  
        }
        if (mapName == "MidAutumnNighttime")
        {
            int mapprogress = PlayerPrefs.GetInt("map3");
            if (mapprogress>=1)   GameObject.Find("Stage1").GetComponent<Button>().interactable = true;
            if (mapprogress>=2)   GameObject.Find("Stage2").GetComponent<Button>().interactable = true;
            if (mapprogress>=3)   GameObject.Find("Stage3").GetComponent<Button>().interactable = true;  
        }
    }
    public void Stage11()
    {
        SceneManager.LoadScene("Stage11");
    }
    public void Stage12()
    {
        SceneManager.LoadScene("Stage12");
    }
    public void Stage13()
    {
        SceneManager.LoadScene("Stage12");
    }
    public void Stage21()
    {
        SceneManager.LoadScene("Stage21");
    }
    public void Stage22()
    {
        SceneManager.LoadScene("Stage22");
    }
    public void Stage23()
    {
        SceneManager.LoadScene("Stage23");
    }
    public void Stage31()
    {
        SceneManager.LoadScene("Stage31");
    }
    public void Stage32()
    {
        SceneManager.LoadScene("Stage32");
    }
    public void Stage33()
    {
        SceneManager.LoadScene("Stage33");
    }
    public void Map()
    {
        SceneManager.LoadScene("MapSelect");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
