using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float _movementSpeed = 5f;
    public float speed;

    float _horizontal;
    float _vertical;
    public Rigidbody2D rb;
    Vector2 _movement;


    void Update()
    {
        // Handle input
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }


    void FixedUpdate()
    {
        // Handle Movement
        rb.MovePosition(rb.position + _movement * _movementSpeed * Time.fixedDeltaTime);
    }


}
