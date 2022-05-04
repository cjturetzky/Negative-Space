using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleControlScriptSIMPLE : MonoBehaviour
{
    public bool input = false;
    public int rotateAngle = 45;
    public float smooth = 1f;
    public Vector3 correctRotation = new Vector3(0, 0, 0);

    private GameObject targetHolder;

    public delegate void SolveDelegate();
    public event SolveDelegate solveEvent;
    // To subscribe to the solveEvent, use FindObjectOfType<PuzzleControlScript>().solveEvent += [YOUR METHOD HERE];
    // Start is called before the first frame update
    
    void Start()
    {
        targetHolder = Instantiate(this.gameObject);
        targetHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("w")){
            input = true;
            targetHolder.transform.Rotate(Vector3.right * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.right);
        }
        else if(Input.GetKeyUp("s")){
            input = true;
            targetHolder.transform.Rotate(Vector3.left * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.left);
        }
        else if(Input.GetKeyUp("a")){
            input = true;
            targetHolder.transform.Rotate(Vector3.up * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.up);
        }
        else if(Input.GetKeyUp("d")){
            input = true;
            targetHolder.transform.Rotate(Vector3.down * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.down);
        }
        else if(Input.GetKeyUp("q")){
            input = true;
            targetHolder.transform.Rotate(Vector3.forward * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        }
        else if(Input.GetKeyUp("e")){
            input = true;
            targetHolder.transform.Rotate(Vector3.back * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.back);
        }
        else if(Input.GetKeyDown("r")){
            input = true;
            targetHolder.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        // Smoothly rotate object to match targetRotation
        transform.rotation = Quaternion.Lerp (transform.rotation, targetHolder.transform.rotation, smooth * Time.deltaTime); 
       
        input = false;
    }
}
