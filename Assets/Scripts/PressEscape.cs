using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEscape : MonoBehaviour
{
    
    public GameObject text;
    private bool disabled = false;

    private void Start()
    {
        text.gameObject.SetActive(false);
        FindObjectOfType<PuzzleController>().solveEvent += Disable;
    }

    private void Disable(int data)
    {
        text.SetActive(false);
        disabled = true;
    }
    private void Update()
    {
        if (!disabled)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                text.gameObject.SetActive(true);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            text.gameObject.SetActive(false);
        }
    }
}
