using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    private bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown, tap;
    private bool isDragging, IsHolding = false;

    private Vector2 startTouch, swipeDelta;

    private Vector2 SwipeDelta
    {
        get { return swipeDelta; }
    }

    public bool swipeLeft
    {
        get { return SwipeLeft; }
    }

    public bool swipeRight
    {
        get { return SwipeRight; }
    }

    public bool swipeDown
    {
        get { return SwipeDown; }
    }

    public bool swipeUp
    {
        get { return SwipeUp; }
    }

    public bool isHolding
    {
        get { return IsHolding; }
    }

    public bool Tap
    {
        get { return tap; }
    }


    private void Update()
    {
        SwipeLeft = SwipeRight = SwipeUp = SwipeDown = tap = false;

        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        #endregion

        #region Mobile Inputs

        if (Input.touchCount != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                IsHolding = true;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                IsHolding = false;
                Reset();
            }
        }

        #endregion

        swipeDelta = Vector2.zero;

        //calculating the distance

        if (isDragging)
        {
            if (Input.touchCount != 0)
            {
                isDragging = true;
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                isDragging = false;
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
            }
        }

        //deadzone?
        if (swipeDelta.magnitude > 30)
        {
            //which dir?
            IsHolding = false;
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0) SwipeLeft = true;
                else SwipeRight = true;
            }
            else
            {
                if (y < 0) SwipeDown = true;
                else SwipeUp = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
        IsHolding = false;
    }
}