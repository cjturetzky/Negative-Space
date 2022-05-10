using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    private int doorNum = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Door " + doorNum + " unlocked");
            GameObject.Find("DoorTrigger_" + doorNum).GetComponent<TriggerDoorController>().unlocked = true;
            doorNum++;
        }
    }
}
