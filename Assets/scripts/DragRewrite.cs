using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragRewrite : MonoBehaviour
{
    float deltaX, deltaY;
    bool isDragging = false;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        // On click down, check if this object was clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                isDragging = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                deltaX = mousePos.x - transform.position.x;
                deltaY = mousePos.y - transform.position.y;
            }
        }

        // While held, move the object
        if (Mouse.current.leftButton.isPressed && isDragging)
        {
            rb.MovePosition(new Vector2(mousePos.x - deltaX, mousePos.y - deltaY));
        }

        // On release, stop dragging
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}