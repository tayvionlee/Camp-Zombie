using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private int health = 100;
    [SerializeField] private float speed = 15f;

    // holds movement input
    private Vector2 _movementInput;
    // holds smooth movement input
    private Vector2 _smoothedMovementInput;
    // keep track of the veolocity of the change
    private Vector2 _movementInputSmoothVelocity;
    // rigidbody reference
    Rigidbody2D rb;

    // move speed
    private float moveSpeed = 5f;

    // dash
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;

    // timers
    private float dashCounter;
    private float dashCoolCounter;

    public Camera cam;

    void Start()
    {
        activeMoveSpeed = speed;
    }

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        //
        PlayerDash();

        //
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void PlayerDash()
    {
        // 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        // 
        if (dashCounter >= 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        //
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection = mousePos - rb.position;

        // smoothing
        rb.velocity = _smoothedMovementInput;
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput,
            ref _movementInputSmoothVelocity, 0.1f);
    }

    private void OnMove(InputValue inputValue)
    {
        // Get vector2 value
        _movementInput = inputValue.Get<Vector2>() * speed;
    }
}