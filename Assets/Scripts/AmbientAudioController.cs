using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioController : MonoBehaviour
{
    public List<AudioClip> music;

    private AudioSource _audio;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var clip in music)
        {
            clip.LoadAudioData();
        }

        _audio = GetComponent<AudioSource>();
        _audio.clip = music[0];
        _audio.loop = true;
        _audio.Play();
    }
}
