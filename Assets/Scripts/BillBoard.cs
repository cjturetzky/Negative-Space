using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    public Camera main;
    //always called after regular update in case camera moves
    private void LateUpdate()
    {
        transform.LookAt(transform.position + main.transform.forward);
        //transform.position = Camera.main.WorldToScreenPoint(transform.position + posOffset);
    }
}
