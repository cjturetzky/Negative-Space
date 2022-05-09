using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject myCamera;
    public GameObject playerCamera;
    public CharacterController playerController;

    private float distanceToPlayer;
    private Transform myPosition;
    private PuzzleController _puzzle;
    private playermovement _player;


    void Start()
    {
        playerCamera.SetActive(true);
        myCamera.SetActive(false);
        myPosition = myCamera.transform;
        _puzzle = GetComponent<PuzzleController>();
        _puzzle.solveEvent += ExitPuzzle;
        _player = GameObject.FindWithTag("Player").GetComponent<playermovement>();
    }

    void Update()
    {
        distanceToPlayer = (myPosition.position - playerCamera.transform.position).magnitude;
        if (Input.GetKeyDown(KeyCode.C) && distanceToPlayer < 5)
        {
            EnterPuzzle();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPuzzle(0);
        }
    }

    private void EnterPuzzle()
    {
        playerCamera.SetActive(false);
        myCamera.SetActive(true);
        playerController.enabled = false;
        _puzzle.locked = false;
        _player.inPuzzle = true;
        //disable player movement
    }

    public void ExitPuzzle(int data)
    {
        myCamera.SetActive(false);
        playerCamera.SetActive(true);
        playerController.enabled = true;
        _puzzle.locked = true;
        _player.inPuzzle = false;
        //enable player movement
    }
}
