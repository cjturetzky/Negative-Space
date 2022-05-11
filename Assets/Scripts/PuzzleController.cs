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
    public float smooth = 3f;
    public bool locked = true;
    public Vector3 correctRotation = Vector3.zero, offset = Vector3.zero;

    private float _tempAngle;
    private Vector3 _axis = Vector3.zero;
    private Queue<Vector3> _queuedAxes;
    

    public delegate void SolveDelegate(int data);

    public event SolveDelegate solveEvent;
    // To subscribe to the solveEvent, use FindObjectOfType<PuzzleController>().solveEvent += [YOUR METHOD HERE];

    private void Start()
    {
        _queuedAxes = new Queue<Vector3>();
    }

    private void RotateAxis()
    {
        transform.Rotate(rotateAngle * Time.fixedDeltaTime * _axis * smooth, Space.World);
        _tempAngle += rotateAngle * Time.fixedDeltaTime;

        if (_tempAngle >= rotateAngle)
        {
            _tempAngle = 0f;

            if (_queuedAxes.Count > 0)
            {
                if (CheckRotation())
                {
                    locked = true;
                    solveEvent?.Invoke(doorsUnlocked);
                }
                
                _axis = _queuedAxes.Peek();
                _queuedAxes.Dequeue();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (locked) return;

        if (_queuedAxes.Count > 0)
        {
            RotateAxis();
        }

        if (Input.GetKeyDown("w"))
        {
            _queuedAxes.Enqueue(Vector3.right);
        }
        else if (Input.GetKeyDown("s"))
        {
            _queuedAxes.Enqueue(Vector3.left);
        }
        else if (Input.GetKeyDown("a"))
        {
            _queuedAxes.Enqueue(Vector3.up);
        }
        else if (Input.GetKeyDown("d"))
        {
            _queuedAxes.Enqueue(Vector3.down);
        }
        else if (Input.GetKeyDown("r"))
        {
            transform.rotation = quaternion.identity;
            _queuedAxes.Clear();
            _axis = Vector3.zero;
        }
        
    }


private bool CheckRotation()
    {
        var x = transform.localRotation.eulerAngles.x;
        var y = transform.localRotation.eulerAngles.y;
        var z = transform.localRotation.eulerAngles.z;
        
        return x < correctRotation.x + 1 && x > correctRotation.x - 1 && 
               y < correctRotation.y + 1 && y > correctRotation.y - 1 && 
               z < correctRotation.z + 1 && z > correctRotation.z - 1;

        
    }
}
