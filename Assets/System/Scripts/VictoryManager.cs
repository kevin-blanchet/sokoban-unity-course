using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    private int targetMax = 0;
    private int targetActive = 0;
    private StateManager stateManager;

    public delegate void Victory();
    public Victory eventVictory;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<StateManager>();

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        targetMax = targets.Length;
        foreach (var target in targets)
        {
            TargetBehaviour targetBehaviour = target.GetComponent<TargetBehaviour>();
            targetBehaviour.onTargetActive += AddTarget;
            targetBehaviour.offTargetActive += RemoveTarget;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(targetActive == targetMax && !stateManager.IsVictory && !stateManager.IsCrateMoving)
        {
            eventVictory();
        }
    }

    private void AddTarget()
    {
        targetActive++;
    }
    private void RemoveTarget()
    {
        targetActive--;
    }
}
