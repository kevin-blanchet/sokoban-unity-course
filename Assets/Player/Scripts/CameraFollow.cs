using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
