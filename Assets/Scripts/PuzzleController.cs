using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PuzzleController : MonoBehaviour
{
    public int rotateAngle = 45;
    public float smooth = 1f;
    public bool locked = true;
    public Vector3 correctRotation = Vector3.zero, offset = Vector3.zero;
    
    private float _tempAngle;
    private Vector3 _axis = Vector3.zero;
    private bool _active = false;
    
    public delegate void SolveDelegate();
    public event SolveDelegate solveEvent;
    // To subscribe to the solveEvent, use FindObjectOfType<PuzzleControlScript>().solveEvent += [YOUR METHOD HERE];

    private void RotateAxis()
    {
        transform.Rotate(rotateAngle * Time.fixedDeltaTime * _axis, Space.World);
        _tempAngle += rotateAngle * Time.fixedDeltaTime;

        if (_tempAngle >= rotateAngle)
        {
            _tempAngle = 0f;
            _active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (locked) return;
        
        if (_active)
        {
            RotateAxis();
            
            if (CheckRotation())
            {
                locked = true;
                solveEvent?.Invoke();
            }
            
            return;
        }
        
        if (Input.GetKeyUp("w"))
        {
            _active = true;
            _axis = Vector3.up;
        }
        else if (Input.GetKeyUp("s"))
        {
            _active = true;
            _axis = Vector3.down;
        }
        else if (Input.GetKeyUp("a"))
        {
            _active = true;
            _axis = Vector3.left;
        }
        else if (Input.GetKeyUp("d"))
        {
            _active = true;
            _axis = Vector3.right;
        }
        else if (Input.GetKeyDown("r"))
        {
            transform.rotation = quaternion.identity;
            _active = true;
        }
    }

    private bool CheckRotation()
    {
        var x = transform.localRotation.eulerAngles.x;
        var y = transform.localRotation.eulerAngles.y;
        var z = transform.localRotation.eulerAngles.z;
        
        return x < correctRotation.x + 10 && x > correctRotation.x - 10 &&
               y < correctRotation.y + 10 && y > correctRotation.y - 10 &&
               z < correctRotation.z + 10 && z > correctRotation.z - 10;
     }
}
