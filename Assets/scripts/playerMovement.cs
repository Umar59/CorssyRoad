using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerMovement : MonoBehaviour
{
   
  
    [SerializeField] private float timeBeforeNextJump = 1f;
    private float canJump = 0f;
    private bool isHopping;
    
    
    private Animator animator;
    public swipe swipes;
    private Vector2 direction2;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Standalone inputs

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

        #endregion

        if (Time.time > canJump)
        {
            if (swipes.isHolding && !isHopping)
            {
                transform.DOScale(new Vector3(1.18f, 0.7f, 1f), 0.1f);
            }
            else if (swipes.swipeUp && !isHopping)
            {
                float xDifference = 0;
                if (transform.position.x %1 != 0)
                {
                    xDifference = Mathf.Round(transform.position.x) - transform.position.x;
                }
                Move(new Vector3(xDifference,  0, 2), new Vector3(0, 0, 0));
            }
            else if (swipes.swipeDown && !isHopping)
            {
                Move(new Vector3(0,  0,  -2), new Vector3(0, 180, 0));
            }
            else if (swipes.swipeLeft && !isHopping)
            {
                Move(new Vector3(- 2, 0, 0), new Vector3(0, -90, 0));
            }
            else if (swipes.swipeRight && !isHopping)
            {
                Move(new Vector3( 2, 0, 0), new Vector3(0, 90, 0));
            }
            else if (!swipes.isHolding && !isHopping)
            {
                transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
            }
        }

        Debug.DrawLine(transform.position, direction2);

    }
    private void Move(Vector3 direction, Vector3 rotation)
    {
            isHopping = true;
            animator.SetTrigger("hop");
            
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);
            transform.DORotate(rotation, 0.15f, RotateMode.Fast);
            transform.DOMove( transform.position + direction, 0.15f, false);
            
            canJump = Time.time + timeBeforeNextJump;
    }

    private void isItHopping()
    {
        isHopping = false;

    }
}
