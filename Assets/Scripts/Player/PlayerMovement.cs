using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameManager gameManager;

    private Vector2 moveVector;
    public Vector2 facingDirection { get; private set; } = Vector2.right;

    private Rigidbody2D playerRigidBody;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!(-transform.position.y > gameManager.MaxDepth))
        {
            playerRigidBody.AddForce(moveSpeed * Time.deltaTime * moveVector);
        }

        if (-transform.position.y > gameManager.MaxDepth)
        {
            transform.position = new Vector3(transform.position.x, -(gameManager.MaxDepth - 1), transform.position.z);
        }

        if (transform.position.y > gameManager.TopBorder)
        {
            transform.position = new Vector3(transform.position.x, gameManager.TopBorder, transform.position.z);
        }
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
