using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private int doorNum = 1;

    private void Start()
    {
        foreach (var puzzle in FindObjectsOfType<PuzzleController>())
        {
            puzzle.solveEvent += OpenDoor;
        }
    }

    private void OpenDoor(int doors)
    {
        for (var i = 0; i < doors; i++)
        {
            doorNum += i;
            Debug.Log("Door " + doorNum + " unlocked");
            GameObject.Find("DoorTrigger_" + doorNum).GetComponent<TriggerDoorController>().unlocked = true;
        }

        doorNum++;
    }
}
