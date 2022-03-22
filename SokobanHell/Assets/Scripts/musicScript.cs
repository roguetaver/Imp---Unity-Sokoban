using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musicScript : MonoBehaviour
{
    private AudioSource aS;
    public AudioMixer mixer;

    void Start()
    {
        int numMusic = FindObjectsOfType<musicScript>().Length;
        if (numMusic != 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Awake()
    {
        aS = GetComponent<AudioSource>();
        aS.volume = PlayerPrefs.GetFloat("volume", 0.2f);
    }

    public void AdjustVol(float vol)
    {
        //aS.volume = vol;
        mixer.SetFloat("volume",Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("volume", vol);
    }
}
