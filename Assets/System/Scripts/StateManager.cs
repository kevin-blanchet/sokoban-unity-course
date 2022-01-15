using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private bool isVictory = false;
    public bool IsVictory { get { return isVictory; } }

    private bool isCrateMoving = false;
    public bool IsCrateMoving { get { return isCrateMoving; } }

    private void Awake()
    {
        GameObject[] crates = GameObject.FindGameObjectsWithTag("Crate");
        foreach (var crate in crates)
        {
            CrateMove crateMove = crate.GetComponent<CrateMove>();
            crateMove.onCrateMove += CrateMoving;
            crateMove.offCrateMove += CrateNotMoving;
        }

        GetComponent<VictoryManager>().eventVictory += Victory;
    }

    private void Victory()
    {
        isVictory = true;
    }

    private void CrateMoving()
    {
        isCrateMoving = true;
    }
    private void CrateNotMoving()
    {
        isCrateMoving = false;
    }
}