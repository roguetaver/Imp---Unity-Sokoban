using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;
    private GameObject music;

    void Start()
    {
        slider = GetComponent<Slider>();
        music = GameObject.Find("Music");
        slider.value = PlayerPrefs.GetFloat("volume", 0.4f);

        if (slider != null)
        {
            slider.onValueChanged.AddListener(value => music.GetComponent<musicScript>().AdjustVol(slider.value));
        }
        else
        {
            Debug.LogError("erro");
        }
    }
}
