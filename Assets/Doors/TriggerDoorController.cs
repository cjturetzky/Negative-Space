using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    private AudioSource _audio;

    public bool unlocked = false;

    private void Start()
    {
	    _audio = GetComponent<AudioSource>();
	    _audio.clip.LoadAudioData();
    }

    private void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player") && unlocked){
			myDoor.Play("DoorOpen",0,0.0f);
			_audio.Play();
		}
	}

	private void OnTriggerExit(Collider col){
		if(col.CompareTag("Player") && unlocked){
			myDoor.Play("DoorClose",0,0.0f);
			_audio.Play();
		}
	}
}
