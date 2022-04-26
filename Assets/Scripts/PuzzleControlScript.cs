using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControlScript : MonoBehaviour
{
    public int rotateAngle = 45;
    public float smooth = 1f;
    public Vector3 correctRotation = new Vector3(90, 45, 0);
    // Symmetries: 1, 45, 90, 180, 360
    // 1 = all rotations valid, 360 = one rotation valid
    public Vector3 symmetries = new Vector3(360, 360, 360);
    public bool xSolve = false;
    public bool ySolve = false;
    public bool zSolve = true;
    private Transform targetRotation;
    private Transform initialRotation;
    private GameObject targetHolder;
    public delegate void SolveDelegate();
    public event SolveDelegate solveEvent;
    // To subscribe to the solveEvent, use FindObjectOfType<PuzzleControlScript>().solveEvent += [YOUR METHOD HERE];
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
        if(CheckRotation()){
            Debug.Log("Solved!");
            if(solveEvent != null){
                solveEvent();
            }
        }
    }

    bool CheckRotation(){
        return(transform.rotation.eulerAngles == correctRotation);
        // if(transform.eulerAngles.x % symmetries.x == correctRotation.x % symmetries.x){
        //     xSolve = true;
        // }
        // else{
        //     xSolve = false;
        // }
        // if(transform.eulerAngles.y % symmetries.y == correctRotation.y % symmetries.y){
        //     ySolve = true;
        // }
        // else{
        //     ySolve = false;
        // }
        // if(transform.eulerAngles.z % symmetries.z == correctRotation.z % symmetries.z){
        //     zSolve = true;
        // }
        // else{
        //     zSolve = false;
        // }

        // return (xSolve && ySolve && zSolve);
    }
}
