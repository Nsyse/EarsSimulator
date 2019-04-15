using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float CharacterSpeed;

    private Rigidbody2D rb = null;
    private Animator anim = null;

    private Vector2 MovementDirection = new Vector2();
    
    private bool GoingUp = false;
    private bool GoingDown = false;
    private bool GoingRight = false;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ReadMoveInputs();
        SetAnimationFlags();
        Move();
    }

    private void SetAnimationFlags()
    {
        bool isWalking = MovementDirection.magnitude != 0;
        
        anim.SetBool("Walking", isWalking);
        anim.SetFloat("WalkRight", MovementDirection.x);
        anim.SetFloat("WalkUpDown", MovementDirection.y);
    }

    private void Move()
    {
        rb.velocity = MovementDirection * CharacterSpeed;
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
        
        MovementDirection = new Vector2();

        if (GoingUp)
        {
            MovementDirection += Vector2.up;
        }

        if (GoingDown)
        {
            MovementDirection += Vector2.down;
        }
        if (GoingRight)
        {
            MovementDirection += Vector2.right;
        }
        
        MovementDirection.Normalize();
    }

    private bool RegisterInput(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }
}
