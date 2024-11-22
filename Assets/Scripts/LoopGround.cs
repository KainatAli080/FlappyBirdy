using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float speedOfLoop = 1.3f;
    [SerializeField] private float width = 6f;

    private SpriteRenderer spriteRenderer;
    private Vector2 startSize;

    private void Start()
    {
        // this will get us sprite renderer component of the object this script is attached to
        spriteRenderer = GetComponent<SpriteRenderer>();
        startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }

    private void Update()
    {
        // Updating the width of the ground
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + (speedOfLoop * Time.deltaTime), spriteRenderer.size.y);

        // Resetting the width and height to initial values once they reach the 6f limit
        if (spriteRenderer.size.x > width) {
            spriteRenderer.size = startSize;
        }
    }
}
