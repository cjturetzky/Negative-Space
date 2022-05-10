using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audio;
    private CharacterController _controller;
    private playermovement _player;

    // Start is called before the first frame update
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip.LoadAudioData();
        _controller = GetComponent<CharacterController>();
        _player = GetComponent<playermovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_controller.velocity.sqrMagnitude) > 0 && !_audio.isPlaying)
        {
            _audio.Play();
        }
        else if (Mathf.Abs(_controller.velocity.sqrMagnitude) <= 0 || _player.inPuzzle)
        {
            _audio.Pause();
        }
    }
}
