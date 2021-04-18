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
    public Vector2 direction2;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(swipes.isHolding);
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

        // if (swipes.Tap)
        // {
        //     isHopping = true;
        //     animator.SetTrigger("hop");
        //
        //     transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);
        //
        //     transform.DOMoveZ((transform.position.z + 2), 0.15f, false);
        //     transform.DORotate(new Vector3(0, 0, 0), 0.15f, RotateMode.Fast);
        //     canJump = Time.time + timeBeforeNextJump;
        // }
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
        else if (!swipes.isHolding)
        {
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
        }

        Debug.DrawLine(transform.position, direction2);

    }




    private void isItHopping()
    {
        isHopping = false;

    }
}
