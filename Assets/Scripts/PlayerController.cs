using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 50.0f;
    [SerializeField] float moveSpeed = 20.0f;
    [SerializeField] float boostSpeed = 40.0f;
    // [SerializeField] SurfaceEffector2D surfaceEffector2D;  // Approach 1: Assign the SurfaceEffector2D in the Inspector
    [SerializeField] GameObject levelSprite;  // Approach 2: Assign the gameobject with SurfaceEffector2D in the Inspector


    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;  // Approach 2
    // SurfaceEffector2D surfaceEffector2D; // Approach 3: Use FindObjectOfType to get the SurfaceEffector2D


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();  // Approach 3
        surfaceEffector2D = levelSprite.GetComponent<SurfaceEffector2D>(); // Approach 2

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = moveSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
