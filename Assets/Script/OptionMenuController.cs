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
        if (!PlayerPrefs.HasKey("difficulty")) PlayerPrefs.SetInt("difficulty", 1);
        if (!PlayerPrefs.HasKey("volume")) PlayerPrefs.SetInt("volume", 3);
        PlayerPrefs.Save();
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
        int d = int.Parse(arg0);
        PlayerPrefs.SetInt("difficulty", d);
        PlayerPrefs.Save();
    }
    private void SubmitVol(string arg0)
    {
        int v = int.Parse(arg0);
        v = Mathf.Clamp(v, 0, 100);
        PlayerPrefs.SetInt("volume", v);
        PlayerPrefs.Save();
    }
}
