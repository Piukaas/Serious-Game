using System;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        float volumeLevel = PlayerPrefs.GetFloat("volume", 0.1f);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = volumeLevel;
            sound.source.loop = sound.loop;
        }
    }

    void Start()
    {
        Play("Theme");
    }

    void Update()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.volume = PlayerPrefs.GetFloat("volume", 0.1f);
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        sound.source.Play();
    }
}
