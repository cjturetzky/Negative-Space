using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControlScript : MonoBehaviour
{
    public float rotateAngle = 45f;
    Vector3 rotateX;
    Vector3 rotateY;
    Vector3 rotateZ;
    // Start is called before the first frame update
    void Start()
    {
        rotateX = new Vector3(rotateAngle, 0, 0);
        rotateY = new Vector3(0, rotateAngle, 0);
        rotateZ = new Vector3(0, 0, rotateAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")){
            transform.Rotate(rotateX, Space.World);
        }
        else if(Input.GetKeyDown("s")){
            transform.Rotate(-rotateX, Space.World);
        }
        else if(Input.GetKeyDown("a")){
            transform.Rotate(rotateZ, Space.World);
        }
        else if(Input.GetKeyDown("d")){
            transform.Rotate(-rotateZ, Space.World);
        }
        else if(Input.GetKeyDown("q")){
            transform.Rotate(rotateY, Space.World);
        }
        else if(Input.GetKeyDown("e")){
            transform.Rotate(-rotateY, Space.World);
        }
    }
}
