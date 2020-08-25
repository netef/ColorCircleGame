using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 6f;
    private bool mouseClicked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClicked = true;
            rb.gravityScale = 2;
        }
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
