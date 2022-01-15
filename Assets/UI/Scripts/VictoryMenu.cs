using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    void Awake()
    {
        GameObject.Find("Manager").GetComponent<VictoryManager>().eventVictory += ActivateCanvas;
    }

    private void ActivateCanvas()
    {
        GetComponent<Canvas>().enabled = true;
    }
}
