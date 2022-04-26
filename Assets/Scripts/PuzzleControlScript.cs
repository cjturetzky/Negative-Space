using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControlScript : MonoBehaviour
{
    public int rotateAngle = 45;
    public float smooth = 1f;
    public Vector3 correctRotation = new Vector3(90, 45, 0);
    private Transform targetRotation;
    private Transform initialRotation;
    private GameObject targetHolder;
    // Start is called before the first frame update
    void Start()
    {
        targetHolder = Instantiate(this.gameObject);
        targetHolder.SetActive(false);
        targetRotation = targetHolder.transform;
        initialRotation = targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")){
            targetHolder.transform.Rotate(Vector3.right * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.right);
        }
        else if(Input.GetKeyDown("s")){
            targetHolder.transform.Rotate(Vector3.left * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.left);
        }
        else if(Input.GetKeyDown("a")){
            targetHolder.transform.Rotate(Vector3.up * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.up);
        }
        else if(Input.GetKeyDown("d")){
            targetHolder.transform.Rotate(Vector3.down * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.down);
        }
        else if(Input.GetKeyDown("q")){
            targetHolder.transform.Rotate(Vector3.forward * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        }
        else if(Input.GetKeyDown("e")){
            targetHolder.transform.Rotate(Vector3.back * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.back);
        }
        else if(Input.GetKeyDown("r")){
            targetHolder.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        // Smoothly rotate object to match targetRotation
        transform.rotation = Quaternion.Lerp (transform.rotation, targetHolder.transform.rotation, smooth * Time.deltaTime); 
        CheckRotation();
    }

    void CheckRotation(){
        if(transform.rotation.eulerAngles == correctRotation){
            Debug.Log("Solved!");
        }
    }
}
