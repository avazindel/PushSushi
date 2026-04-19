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
        if (Input.touchCount > 0)
        {
            //get mouse cursor holding down
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    //if object touched has a collider and this script
                    if(GetComponent<Collider2D> () == Physics2D.OverlapPoint(touchPos))
                    {
                        //then you can move this object
                        thisColTouched = true;
                        moveAllowed = true;
                        rb.bodyType = RigidbodyType2D.Dynamic;

                        //deterine move point
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }

                    break;

                case TouchPhase.Moved:

                    if (moveAllowed && thisColTouched)
                    {
                        rb.MovePosition(new Vector2(touchPos.x - deltaX,
                            touchPos.y - deltaY));
                    }
                    break;

                //case TouchPhase.Ended:
                //case TouchPhase.Cancelled:
                    //thisColTouched = false;
                    //moveAllowed = false;
                    //rb.bodyType = RigidbodyType2D.Kinematic;
                    //break;

            }

        }
    }
}
