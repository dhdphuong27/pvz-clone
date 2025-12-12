using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public Sound[] sounds;

    public static void Play(string name)
    {
        if (Instance != null)
        {
            Instance.PlayAudio(name);
            return;
        }
        // Fallback: try to find an AudioManager in the scene (non-deprecated API)
        AudioManager fallback = UnityEngine.Object.FindFirstObjectByType<AudioManager>();
        if (fallback != null)
        {
            fallback.PlayAudio(name);
            return;
        }
        Debug.LogWarning("AudioManager not available when trying to play: " + name);
    }
    public void PlayAudio(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                if (s.name.Contains("hit"))
                {
                    s.source.Play();
                }
                if (!s.source.isPlaying)
                {
                    s.source.Play();
                }
            }
        }
    }
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Multiple AudioManager instances detected — destroying duplicate.");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = PlayerPrefs.GetInt("volume")/10f;
            Debug.Log(s.source.volume);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
}
