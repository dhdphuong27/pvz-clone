using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedController : MonoBehaviour
{
    private bool turbo;
    private bool pause;
    public Button button;
    public Sprite turboSprite;
    public Sprite turboActivatedSprite;
    public Sprite pauseSprite;
    public Sprite pauseActivatedSprite;

    public void TurboActivate()
    {
        if (turbo)
        {
            Time.timeScale = 1F;
            turbo = false;
            GameObject.Find("Turbo").GetComponent<Image>().sprite = turboSprite;
        }
        else
        {
            Time.timeScale = 2F;
            turbo = true;
            GameObject.Find("Turbo").GetComponent<Image>().sprite = turboActivatedSprite;
        }
        
    }
    public void PauseActive()
    {
        if (pause)
        {
            Time.timeScale = 1F;
            pause = false;
            GameObject.Find("Pause").GetComponent<Image>().sprite = pauseSprite;
        }
        else
        {
            Time.timeScale = 0F;
            pause = true;
            GameObject.Find("Pause").GetComponent<Image>().sprite = pauseActivatedSprite;
        }
    }
}
