using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenuController : MonoBehaviour
{
    public InputField inputdiff;
    public InputField inputvol;
    public void Awake()
    {
        GameObject.Find("InputDiff").GetComponent<InputField>().text = PlayerPrefs.GetInt("difficulty").ToString();
        GameObject.Find("InputVol").GetComponent<InputField>().text = PlayerPrefs.GetInt("volume").ToString();   
    }
    public void Exit()
    {
        SubmitDiff(GameObject.Find("InputDiff").GetComponent<InputField>().text);
        SubmitVol(GameObject.Find("InputVol").GetComponent<InputField>().text);
        if (GameObject.Find("ToggleScreen").GetComponent<Toggle>().isOn)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else
        {
            Screen.SetResolution(1920, 1080, false);
        }
        SceneManager.LoadScene("MainMenu");
    }
    private void SubmitDiff(string arg0)
    {
        PlayerPrefs.SetInt("difficulty", int.Parse(arg0));
    }
    private void SubmitVol(string arg0)
    {
        PlayerPrefs.SetInt("volume", int.Parse(arg0));
    }
}
