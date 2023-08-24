using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 moveVector;
    public Vector2 facingDirection { get; private set; } = Vector2.right;

    private Rigidbody2D playerRigidBody;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerRigidBody.AddForce(moveSpeed * Time.deltaTime * moveVector);
    }

    private void OnMove(InputValue inputValue)
    {
        moveVector = inputValue.Get<Vector2>();

        if (moveVector != Vector2.zero)
        {
            facingDirection = moveVector;
        }
    }
}