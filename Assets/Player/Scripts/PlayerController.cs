using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private PlayerInput playerInput;
    private InputAction move;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        move = playerInput.actions["Move"];
    }

    void Update()
    {
        Vector3 movement = new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }

    private void OnEnable()
    {
        move.Enable();

        playerInput.actions["Jump"].performed += DoJump;
        playerInput.actions["Jump"].Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        playerInput.actions["Jump"].Disable();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("jump");
    }
}
