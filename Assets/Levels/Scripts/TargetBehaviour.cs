using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    [System.NonSerialized] public bool active;

    public delegate void IsTargetActive();
    public IsTargetActive onTargetActive;
    public IsTargetActive offTargetActive;

    public void onCrateEnter()
    {
        Debug.Log("target active");
        active = true;
        onTargetActive();
    }
    public void onCrateExit()
    {
        Debug.Log("target inactive");
        active = false;
        offTargetActive();
    }
}
