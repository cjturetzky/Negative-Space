using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject myCamera;
    public GameObject playerCamera;

    private float distanceToPlayer;
    private Transform myPosition;
    private PuzzleController _puzzle;
    private playermovement _player;
    private bool solved = false;


    void Start()
    {
        playerCamera.SetActive(true);
        myCamera.SetActive(false);
        myPosition = myCamera.transform;

        _puzzle = GetComponent<PuzzleController>();
        _puzzle.solveEvent += EndPuzzle;
        _player = GameObject.FindWithTag("Player").GetComponent<playermovement>();
    }

    void Update()
    {
        if (!solved)
        {
            distanceToPlayer = (myPosition.position - playerCamera.transform.position).magnitude;
            if (Input.GetKeyDown(KeyCode.E) && distanceToPlayer < 5)
            {
                EnterPuzzle();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ExitPuzzle(0);
            }
        }
    }

    private void EnterPuzzle()
    {
        playerCamera.SetActive(false);
        myCamera.SetActive(true);
        _player.inPuzzle = true;
        _puzzle.locked = false;
    }

    private void ExitPuzzle(int data)
    {
        myCamera.SetActive(false);
        playerCamera.SetActive(true);
        _player.inPuzzle = false;
        _puzzle.locked = true;
    }
    
    private void EndPuzzle(int data)
    {
        solved = true;
        myCamera.SetActive(false);
        playerCamera.SetActive(true);
        _player.inPuzzle = false;
        _puzzle.locked = true;
    }
    
}
