using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float CharacterSpeed;

    private Rigidbody2D rb = null;
    
    private bool GoingUp = false;
    private bool GoingDown = false;
    private bool GoingRight = false;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadMoveInputs();
        SetAnimationFlags();
        Move();
    }

    private void SetAnimationFlags()
    {
        if (GoingUp)
        {
            //Set Going up animation flag
        }
        else if(GoingDown)
        {
            //Set Going up animation flag
        }
        else if(GoingRight)
        {
            //Set Going right animation flag
        }
    }

    private void Move()
    {
        Vector3 movementDirection = new Vector3();

        if (GoingUp)
        {
            movementDirection += Vector3.up;
        }

        if (GoingDown)
        {
            movementDirection += Vector3.down;
        }
        if (GoingRight)
        {
            movementDirection += Vector3.right;
        }
        
        movementDirection.Normalize();

        rb.velocity = movementDirection * CharacterSpeed;
    }

    private void ReadMoveInputs()
    {
        GoingUp = RegisterInput(KeyCode.W);
        GoingRight = RegisterInput(KeyCode.D);
        GoingDown = RegisterInput(KeyCode.S);

        if (GoingUp && GoingDown)
        {
            GoingUp = false;
            GoingDown = false;
        }
    }

    private bool RegisterInput(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }
}
