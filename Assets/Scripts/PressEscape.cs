using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEscape : MonoBehaviour
{
    
    public GameObject text;
    
    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            text.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            text.gameObject.SetActive(false);
        }
    }
}
