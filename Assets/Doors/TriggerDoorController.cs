using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
	
	public bool unlocked = false;

	private void OnTriggerEnter(Collider col){
		if(col.CompareTag("Player") && unlocked){
			myDoor.Play("DoorOpen",0,0.0f);
		}
	}

	private void OnTriggerExit(Collider col){
		if(col.CompareTag("Player") && unlocked){
			myDoor.Play("DoorClose",0,0.0f);
		}
	}
}
