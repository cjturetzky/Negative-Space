using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject myCamera;
    public GameObject playerCamera;
    public CharacterController playerController;

    private float distanceToPlayer;
    private Transform myPosition;
    

    void Start()
    {
     playerCamera.SetActive(true); 
     myCamera.SetActive(false);

     myPosition = myCamera.transform;
    }
    
    void Update()
    {
        distanceToPlayer = (myPosition.position - playerCamera.transform.position).magnitude;
        if (Input.GetKeyDown(KeyCode.E) && distanceToPlayer < 5)
        {
            playerCamera.SetActive(false);
            myCamera.SetActive(true);
            playerController.enabled = false;
            //disable player movement
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            myCamera.SetActive(false);
            playerCamera.SetActive(true);
            playerController.enabled = true;
            //enable player movement
        }
        
        
    }
}
