using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotation_speed = 10f;

    private Rigidbody2D rb_birdy; 

    // Start is called before the first frame update
    private void Start()
    {
        rb_birdy = GetComponent<Rigidbody2D>();   // This gets the rigidBody this script is attached to, in this case, flappy bird
    }

    // More suitable for non-physics based interactions such as input reading, animations and such
    // Update is called once per frame
    private void Update()
    {
        // Checks if the player touches the screen (for mobile) or clicks the mouse (for testing in editor)
        // Uses Unity in-built input system instead of new updated one right now.
        // This is enough for simple input reading, without knowing where exactly the user clicked
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            // Apply an upward force to simulate jumping
            rb_birdy.velocity = Vector2.up * velocity;
        }
    }

    // More suitable for executing physics based interactions
    // time dependent
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb_birdy.velocity.y * rotation_speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
