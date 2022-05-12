using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed = 12f;
    public bool inPuzzle = false;
    //public AudioSource audio;

    private float gravity = 9.8f;
    private float vSpeed = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPuzzle)
        {
            return;
        }
        else
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
        
            Vector3 move = transform.right * x + transform.forward * z;
        
            if (controller.isGrounded)
            {
                vSpeed = 0;
            }

            vSpeed -= gravity * Time.deltaTime;
            move.y = vSpeed;
        
            controller.Move(move * speed * Time.deltaTime);
        }
        
    }
}
