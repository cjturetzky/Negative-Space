using UnityEngine;

public class RotateItem : MonoBehaviour
{
    void Update()
    {
        // TODO : make rotation relative to camera, not world
        
        // X Axis
        if (Input.GetKeyDown(KeyCode.D))    // +
        {
            transform.Rotate(30.0f, 0.0f, 0.0f);
        }
        
        if (Input.GetKeyDown(KeyCode.A))    // -
        {
            transform.Rotate(-30.0f, 0.0f, 0.0f);
        }
        
        // Y Axis
        if (Input.GetKeyDown(KeyCode.W))    // +
        {
            transform.Rotate(0.0f, 30.0f, 0.0f);
        }
        
        if (Input.GetKeyDown(KeyCode.S))    // -
        {
            transform.Rotate(0.0f, -30.0f, 0.0f);
        }
        
        // Z Axis
        if (Input.GetKeyDown(KeyCode.E))    // +
        {
            transform.Rotate(0.0f, 0.0f, 30.0f);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))    // -
        {
            transform.Rotate(0.0f, 0.0f, -30.0f);
        }
        
        // Reset
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        
    }
}
