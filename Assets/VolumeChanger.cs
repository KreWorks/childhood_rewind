using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
	public Slider volume;
	public AudioSource song;

	
    // Update is called once per frame
    void Update()
    {
		song.volume = volume.value;
    }
}
