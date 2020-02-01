using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void VolumeControl (float Volume)
    {
        audioMixer.SetFloat("Volume", Volume);
    }
}
