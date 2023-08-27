using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = .5f;

    private void Start()
    {
        AudioListener.volume = defaultVolume;
        volumeSlider.value = defaultVolume;
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
