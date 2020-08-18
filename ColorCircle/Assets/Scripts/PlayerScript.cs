using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private float jumpForce = 10f;
    private bool mouseClicked = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
            Debug.Log("click");
        }
    }

    void FixedUpdate()
    {
        if (mouseClicked)
        {
            mouseClicked = false;
            rigidbody.velocity = Vector2.up * jumpForce;
        }
    }
}
