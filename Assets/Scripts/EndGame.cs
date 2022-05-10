using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            Destroy(col);
            SceneManager.LoadScene("End Credits", LoadSceneMode.Single);
        }
    }
}
