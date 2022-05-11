using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PuzzleController : MonoBehaviour
{
    public int rotateAngle = 45, doorsUnlocked = 1;
    public float smooth = 4f;
    public bool locked = true;
    public Vector3 correctRotation = Vector3.zero;
    
    private GameObject reset;
    private GameObject targetHolder;
    
    public bool input;
    private bool redo = false;

    public delegate void SolveDelegate(int data); 
    public event SolveDelegate solveEvent;
    
    private Vector3 oldEulerAngles;

    private void Start()
    {
        targetHolder = Instantiate(gameObject,  gameObject.transform.position, gameObject.transform.rotation);
        targetHolder.SetActive(false);
        
        reset = Instantiate(gameObject,  gameObject.transform.position, gameObject.transform.rotation);
        reset.SetActive(false);
        
        oldEulerAngles = transform.rotation.eulerAngles;
    }

    private void RotateAxis()
    {
        transform.rotation = Quaternion.Slerp (transform.rotation, targetHolder.transform.rotation, smooth * Time.deltaTime);
    }
    
    private void Reset()
    {
        Transform tran = reset.transform;
        targetHolder.transform.rotation = Quaternion.identity * Quaternion.Euler(tran.rotation.x, tran.rotation.y, tran.rotation.z);
        transform.rotation = Quaternion.identity * Quaternion.Euler(tran.rotation.x, tran.rotation.y, tran.rotation.z);
    }
    
    void Update()
    {
        if (locked) return;
        
        if (CheckRotation())
        {
            locked = true;
            solveEvent?.Invoke(doorsUnlocked);
            transform.rotation = Quaternion.identity * Quaternion.Euler(0, 0, -90);
        }
        
        if(Input.GetKeyDown("w") && input == false){ 
            input = true;
            targetHolder.transform.Rotate(Vector3.left * rotateAngle, Space.World);
        }
        else if(Input.GetKeyDown("s") && input == false){
            input = true;
            targetHolder.transform.Rotate(Vector3.right * rotateAngle, Space.World);
        }
        else if(Input.GetKeyDown("a") && input == false){
            input = true;
            targetHolder.transform.Rotate(Vector3.up * rotateAngle, Space.World);
        }
        else if(Input.GetKeyDown("d") && input == false){
            input = true;
            targetHolder.transform.Rotate(Vector3.down * rotateAngle, Space.World);
        }
        else if (Input.GetKeyDown("r") && input == false){
            input = true;
            redo = true;
        }

        //CHECK FOR MOVEMENT TO AVOID "COMBO" ROTATIONS
        if (Mathf.Abs(oldEulerAngles.magnitude - transform.rotation.eulerAngles.magnitude) < 0.2){
            input = false;
            redo = false;
        } else{
            oldEulerAngles = transform.transform.rotation.eulerAngles;
        }
    }

    private void FixedUpdate()
    {
        if (redo)
        {
            Reset();
        }
        else
        {
            RotateAxis();
        }
    }


    private bool CheckRotation()
    {
        var x = transform.localRotation.eulerAngles.x;
        var y = transform.localRotation.eulerAngles.y;
        var z = transform.localRotation.eulerAngles.z;
        
        return x < correctRotation.x + 2.1 && x > correctRotation.x - 2.1 && 
               y < correctRotation.y + 2.1 && y > correctRotation.y - 2.1 && 
               z < correctRotation.z + 2.1 && z > correctRotation.z - 2.1;
    }
}
