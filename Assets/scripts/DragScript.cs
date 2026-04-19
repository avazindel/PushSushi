using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{

    float deltaX, deltaY;
    bool moveAllowed = false;
    bool thisColTouched = false;
    Rigidbody2D rb;


    void Awake()
    {
        Input.simulateMouseWithTouches = true;

        //get rb from bug object
        rb = GetComponent<Rigidbody2D>();

        //obstacle feature??
        rb.bodyType = RigidbodyType2D.Kinematic;

    }


    // Update is called once per frame
    void Update()
    {

        // Decide input source
        bool isTouch = Input.touchCount > 0;
        bool isMouse = Input.GetMouseButton(0);


        Vector3 inputPos = Vector3.zero;
        bool inputBegan = false;
        bool inputMoved = false;
        bool inputEnded = false;

        //Claude input for web build
        if (isTouch)
        {
            Touch touch = Input.GetTouch(0);
            inputPos = Camera.main.ScreenToWorldPoint(touch.position);
            inputBegan = touch.phase == TouchPhase.Began;
            inputMoved = touch.phase == TouchPhase.Moved;
            inputEnded = touch.phase == TouchPhase.Ended;
        }
        else if (isMouse)
        {
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            inputBegan = Input.GetMouseButtonDown(0);
            inputMoved = Input.GetMouseButton(0);
            inputEnded = Input.GetMouseButtonUp(0);
        }

        inputPos.z = 0f;

        // Now use inputBegan / inputMoved / inputEnded exactly like before
        if (inputBegan)
        {
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(inputPos))
            {
                thisColTouched = true;
                moveAllowed = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                deltaX = inputPos.x - transform.position.x;
                deltaY = inputPos.y - transform.position.y;
            }
        }
        else if (inputMoved && moveAllowed && thisColTouched)
        {
            rb.MovePosition(new Vector2(inputPos.x - deltaX, inputPos.y - deltaY));
        }
        else if (inputEnded)
        {
            thisColTouched = false;
            moveAllowed = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    //case TouchPhase.Ended:
    //case TouchPhase.Cancelled:
    //thisColTouched = false;
    //moveAllowed = false;
    //rb.bodyType = RigidbodyType2D.Kinematic;
    //break;

}

