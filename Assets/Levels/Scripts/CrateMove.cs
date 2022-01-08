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
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                isMoving = false;
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
            if (direction != Vector3.zero)
            {
                moveInDirection = direction;
                isMoving = true;
            }
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
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
}
