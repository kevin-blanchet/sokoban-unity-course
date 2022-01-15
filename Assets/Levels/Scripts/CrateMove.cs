using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateMove : MonoBehaviour
{
    private bool isMoving = false;
    private Vector3 moveInDirection = Vector3.zero;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float moveDistance = 1;
    private float moveDistanceCurrent = 0;

    public delegate void IsCrateMoving();
    public IsCrateMoving onCrateMove;
    public IsCrateMoving offCrateMove;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float move = moveDistance * moveSpeed * Time.deltaTime;
            moveDistanceCurrent += move;
            if(moveDistanceCurrent >= moveDistance)
            {
                transform.position += moveInDirection * (moveDistanceCurrent - moveDistance);
                StopMoving();
                moveDistanceCurrent = 0;
            }
            else
            {
                transform.position += moveInDirection * move;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !isMoving)
        {
            Vector3 direction = moveDirection(collision.GetContact(0).point - transform.position);
            Vector3 moveTo = transform.position + moveDistance * direction;
            if (direction != Vector3.zero && isPostionEmpty(moveTo))
            {
                BeginMove(direction);
            }
        }
    }

    private bool isPostionEmpty(Vector3 moveTo)
    {
        GameObject[] crates = GameObject.FindGameObjectsWithTag("Crate");
        foreach (var crate in crates)
        {
            if(crate.transform != transform)
            {
                if(Vector3.Distance(moveTo, crate.transform.position) < moveDistance / 2)
                {
                    return false;
                }
            }
        }
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (Vector3.Distance(moveTo, wall.transform.position) < moveDistance / 2)
            {
                Debug.Log("wall in position");
                return false;
            }
        }
        return true;
    }

    private Vector3 moveDirection(Vector3 from)
    {
        if (Mathf.Abs(from.x) > Mathf.Abs(from.z))
        {
            if (from.x > 0)
            {
                return Vector3.left;
            }
            else
            {
                return Vector3.right;
            }
        }
        else if (Mathf.Abs(from.x) < Mathf.Abs(from.z))
        {
            if (from.z > 0)
            {
                return Vector3.back;
            }
            else
            {
                return Vector3.forward;
            }
        }
        return Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Target"))
        {
            other.gameObject.GetComponent<TargetBehaviour>().onCrateEnter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Target"))
        {
            other.gameObject.GetComponent<TargetBehaviour>().onCrateExit();
        }
    }

    private void BeginMove(Vector3 direction)
    {
        moveInDirection = direction;
        isMoving = true;
        onCrateMove();
    }
    private void StopMoving()
    {
        moveInDirection = Vector3.zero;
        isMoving = false;
        offCrateMove();
    }
}
