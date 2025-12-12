using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.EndEditEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }
    private void SubmitName(string arg0)
    {
        PlayerPrefs.SetString("user1name", arg0);
        this.gameObject.GetComponent<Image>().enabled = false;
        GameObject.Find("NameText").GetComponent<Text>().enabled = false;
        PlayerPrefs.SetInt("map1", 1);
        PlayerPrefs.SetInt("map2", 1);
        PlayerPrefs.SetInt("map3", 1);
        PlayerPrefs.SetInt("map4", 1);
        PlayerPrefs.SetInt("map5", 1);
    }
}
