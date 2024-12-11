using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ActivationPuzzleController : MonoBehaviour
{
    [SerializeField] private List<ColorChanger> playerSequence;
    [SerializeField] private List<ColorChanger> puzzleSequence;
    private bool puzzle1Completed = false;
    private int count;

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
        playerSequence = new List<ColorChanger>();
        count = puzzleSequence.Count();
    }
    private void Start() {
    }
    private void Update() {
        if(!puzzle1Completed && CompareSequences()){
            puzzle1Completed = true;
            LevelManager.instance.SolvePuzzle();
        } else if(playerSequence.Count() == count && !puzzle1Completed){
            RestartSequence();
        }

    }
    public bool AddToPlayerSequence(ColorChanger value)
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

    private bool CompareSequences(){
        
        if (playerSequence.Count() != count){
            return false;
        }
        for(int i =0; i<count; i++){
            if(playerSequence[i]!=puzzleSequence[i]){
                return false;
            }
        }
        return true;
    }
    private void RestartSequence(){
        foreach (var item in playerSequence)
        {
            item.Interaction();
        }
        playerSequence = new List<ColorChanger>();
    }
}