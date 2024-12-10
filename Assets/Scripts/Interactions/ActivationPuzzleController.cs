using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivationPuzzleController : MonoBehaviour
{
    [SerializeField] private List<int> playerSequence;
    [SerializeField] private List<int> puzzleSequence;
    private bool puzzle1Completed = false;

    public static ActivationPuzzleController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        playerSequence = new List<int>();
    }
    private void Update() {
        if(!puzzle1Completed && playerSequence.ToCommaSeparatedString().Equals(puzzleSequence.ToCommaSeparatedString()) ){
            puzzle1Completed = true;
            LevelManager.instance.SolvePuzzle();
        }
    }
    public bool AddToPlayerSequence(int value)
    {
        if(!puzzle1Completed){
            if (playerSequence.Contains(value))
            {
                playerSequence.Remove(value);
                return false;
            }
            playerSequence.Add(value);
            return true;
        }
        return false;
    }

    public void PuzzleInteract(GameObject gameObj)
    {
        if(!puzzle1Completed ){
            gameObj.GetComponent<InteractableObject>().Interaction();
        }
    }
}