using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public InputField inputField;

    public void StartGame()
    {
        StartCoroutine(Wait());
    }
    public void OptionMenu()
    {
        SceneManager.LoadScene("GameOption");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MapSelect");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Awake()
    {
        this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetInt("volume")/10f;
    }
    public void Update()
    {
        if (!PlayerPrefs.HasKey("user1name"))
        {
            GameObject.Find("NameInputField").GetComponent<Image>().enabled = true;
            GameObject.Find("NameText").GetComponent<Text>().enabled = true;
            GameObject.Find("Play Button").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("Play Button").GetComponent<Button>().interactable = true;
            //Debug.Log(PlayerPrefs.GetString("user1name"));
        }
        if (!PlayerPrefs.HasKey("difficulty"))
        {
            PlayerPrefs.SetInt("difficulty", 2);
        }
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetInt("volume", 3);
        }
    }
    public void DeleteUser()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("deleteAll");
    }
}
