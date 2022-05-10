
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControlScript : MonoBehaviour
{
    public bool input = false;
    public int rotateAngle = 45;
    public float smooth = 1f;
    public Vector3 correctRotation = new Vector3(90, 45, 0);
    public Vector3 symmetries = new Vector3(360, 360, 360);
    // 45, 90, 180, & 360 are valid symmetries
    private Transform targetRotation;
    private Transform initialRotation;
    private GameObject targetHolder;
    private GameObject solutionHolder;
    public delegate void SolveDelegate();
    public event SolveDelegate solveEvent;
    // To subscribe to the solveEvent, use FindObjectOfType<PuzzleControlScript>().solveEvent += [YOUR METHOD HERE];
    // Start is called before the first frame update
    void Start()
    {
        targetHolder = Instantiate(this.gameObject);
        solutionHolder = Instantiate(this.gameObject);
        solutionHolder.transform.Rotate(correctRotation, Space.World);
        solutionHolder.SetActive(false);
        targetHolder.SetActive(false);
        targetRotation = targetHolder.transform;
        initialRotation = targetRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w")){
            input = true;
            targetHolder.transform.Rotate(Vector3.right * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.right);
        }
        else if(Input.GetKeyDown("s")){
            input = true;
            targetHolder.transform.Rotate(Vector3.left * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.left);
        }
        else if(Input.GetKeyDown("a")){
            input = true;
            targetHolder.transform.Rotate(Vector3.up * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.up);
        }
        else if(Input.GetKeyDown("d")){
            input = true;
            targetHolder.transform.Rotate(Vector3.down * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.down);
        }
        else if(Input.GetKeyDown("q")){
            input = true;
            targetHolder.transform.Rotate(Vector3.forward * rotateAngle, Space.World);
            //targetRotation *=  Quaternion.AngleAxis(rotateAngle, Vector3.forward);
        }
        else if(Input.GetKeyDown("e")){
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
        if(input){
            if(CheckRotation()){
                Debug.Log("Solved!");
                if(solveEvent != null){
                    solveEvent();
                }
            }
        }
        input = false;
    }

    bool CheckRotation(){
        // Check targetHolder rather than transform to allow for immediate checking of rotation without waiting for Lerp to complete.
        // This allows us to only run this check once when a new input is recieved
        if(targetHolder.transform.rotation == solutionHolder.transform.rotation){
            return true;
        }

        // Save initial rotations
        var initialX = solutionHolder.transform.eulerAngles.x;
        var initialY = solutionHolder.transform.eulerAngles.y;
        var initialZ = solutionHolder.transform.eulerAngles.z;

        // if symmetries._ is 360, it will return to it's initial rotation and not check further
        // otherwise, it will check all valid symmetries

        //Iterate over all valid X rotations
        solutionHolder.transform.Rotate(Vector3.right * symmetries.x, Space.World);
        while(solutionHolder.transform.eulerAngles.x != initialX){
            if(solutionHolder.transform.rotation == targetHolder.transform.rotation){
                return true;
            }
            solutionHolder.transform.Rotate(Vector3.right * symmetries.x, Space.World);
        }

        // Reset solutionHolder rotation to account for small changes due to rotation checks
        solutionHolder.transform.rotation = new Quaternion(0, 0, 0, 0);
        solutionHolder.transform.Rotate(correctRotation, Space.World);

        //Iterate over all valid Y rotations
        solutionHolder.transform.Rotate(Vector3.up * symmetries.y, Space.World);
        while(solutionHolder.transform.eulerAngles.y != initialY){
            if(solutionHolder.transform.rotation == targetHolder.transform.rotation){
                return true;
            }
            solutionHolder.transform.Rotate(Vector3.up * symmetries.y, Space.World);
        }

        // Reset solutionHolder rotation to account for small changes due to rotation checks
        solutionHolder.transform.rotation = new Quaternion(0, 0, 0, 0);
        solutionHolder.transform.Rotate(correctRotation, Space.World);

        // Iterate over all valid Z rotations
        solutionHolder.transform.Rotate(Vector3.forward * symmetries.z, Space.World);
        while(solutionHolder.transform.eulerAngles.z != initialZ){
            if(solutionHolder.transform.rotation == targetHolder.transform.rotation){
                return true;
            }
            solutionHolder.transform.Rotate(Vector3.forward * symmetries.z, Space.World);
        }

        // Reset solutionHolder rotation to account for small changes due to rotation checks
        solutionHolder.transform.rotation = new Quaternion(0, 0, 0, 0);
        solutionHolder.transform.Rotate(correctRotation, Space.World);

        return false;
    }
}