using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivationPuzzleController : MonoBehaviour
{
    [SerializeField] private List<int> playerSequence;
    [SerializeField] private List<int> puzzleSequence;

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
    public bool AddToPlayerSequence(int value)
    {
        if (playerSequence.Contains(value))
        {
            playerSequence.Remove(value);
            return false;
        }
        playerSequence.Add(value);
        return true;
    }

    public void toggleColor(GameObject gameObj)
    {
        gameObj.GetComponent<ColorChanger>().changeColor();
    }
}