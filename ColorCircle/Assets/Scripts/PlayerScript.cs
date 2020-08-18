using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 8f;
    private bool mouseClicked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) mouseClicked = true;
    }

    void FixedUpdate()
    {
        if (mouseClicked)
        {
            mouseClicked = false;
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
