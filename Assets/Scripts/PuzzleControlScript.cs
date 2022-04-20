using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControlScript : MonoBehaviour
{
    public int rotateAngle = 45;
    public float smooth = 1f;
    private Quaternion targetRotation;
    private Quaternion initialRotation;
    Vector3 rotateX;
    Vector3 rotateY;
    Vector3 rotateZ;
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;
        initialRotation = targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")){
            //transform.Rotate(rotateX, Space.World);
            targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.right);
        }
        else if(Input.GetKeyDown("s")){
            //transform.Rotate(-rotateX, Space.World);
            targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.left);
        }
        else if(Input.GetKeyDown("a")){
            //transform.Rotate(rotateZ, Space.World);
            targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.up);
        }
        else if(Input.GetKeyDown("d")){
            //transform.Rotate(-rotateZ, Space.World);
            targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.down);
        }
        else if(Input.GetKeyDown("q")){
            //transform.Rotate(rotateY, Space.World);
            targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        }
        else if(Input.GetKeyDown("e")){
            //transform.Rotate(-rotateY, Space.World);
            targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.back);
        }
        else if(Input.GetKeyDown("r")){
            targetRotation = initialRotation;
        }
        // Smoothly rotate object to match targetRotation
        transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, smooth * Time.deltaTime); 
    }
}
