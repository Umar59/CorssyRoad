using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerMovement : MonoBehaviour
{



    private Animator animator;
    private bool isHopping;
    [SerializeField] private float timeBeforeNextJump = 1f;
    private float canJump = 0f;
    public swipe swipes;
    public Vector2 startPos;
    public Vector2 direction;
    public Vector2 direction2;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isHopping && Time.time > canJump)
        {

            transform.DOScale(new Vector3(1.18f, 0.7f, 1f), 0.1f);
        }

        if (Input.GetKeyUp(KeyCode.Space) && Time.time > canJump)
        {
            isHopping = true;
            animator.SetTrigger("hop");

            transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);

            transform.DOMoveZ((transform.position.z + 2), 0.15f, false);
            canJump = Time.time + timeBeforeNextJump;
            //transform.position = (transform.position + new Vector3(0, 0, 2));
        }


        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);


        //    switch (touch.phase)
        //    {

        //        case TouchPhase.Began:

        //            startPos = touch.position;
        //            transform.DOScale(new Vector3(1.18f, 0.7f, 1f), 0.1f);

        //            break;


        //        case TouchPhase.Moved:

        //            direction = Camera.main.ScreenToWorldPoint(touch.position - startPos);
        //            direction2 = touch.position - startPos;
        //            //y = z, x = x

        //            break;

        //        case TouchPhase.Ended:
        //           Debug.Log(Mathf.Rad2Deg*Mathf.Atan2(direction2.y, direction2.x));



        //            break;
        //    }

        //}
        if (swipes.isHolding)
        {
            transform.DOScale(new Vector3(1.18f, 0.7f, 1f), 0.1f);
        }
       
        else if (swipes.swipeUp)
        {
            isHopping = true;
            animator.SetTrigger("hop");

            transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);

            transform.DOMoveZ((transform.position.z + 2), 0.15f, false);
            transform.DORotate(new Vector3(0,0,0), 0.15f, RotateMode.Fast);
            canJump = Time.time + timeBeforeNextJump;
        }
        else if (swipes.swipeDown)
        {
            isHopping = true;
            animator.SetTrigger("hop");

            transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);

            transform.DOMoveZ((transform.position.z - 2), 0.15f, false);
            transform.DORotate(new Vector3(0,180,0),  0.15f, RotateMode.Fast);

            canJump = Time.time + timeBeforeNextJump;
        } 
        else if (swipes.swipeLeft)
        {
            isHopping = true;
            animator.SetTrigger("hop");

            transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);
            transform.DORotate(new Vector3(0,-90,0), 0.15f, RotateMode.Fast);
            transform.DOMoveX((transform.position.x - 2), 0.15f, false);
            canJump = Time.time + timeBeforeNextJump;
        } 
        else if (swipes.swipeRight)
        {
            isHopping = true;
            animator.SetTrigger("hop");

            transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);
            transform.DORotate(new Vector3(0,90,0), 0.15f, RotateMode.Fast);
            transform.DOMoveX((transform.position.x + 2), 0.15f, false);
            canJump = Time.time + timeBeforeNextJump;
        }
        Debug.DrawLine(transform.position, direction2);

    }




    private void isItHopping()
    {
        isHopping = false;

    }
}
