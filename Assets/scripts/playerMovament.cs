using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerMovament : MonoBehaviour
{



    private Animator animator;
    private bool isHopping;
    [SerializeField] private float timeBeforeNextJump = 1f;
    private float canJump = 0f;
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
            Debug.Log(transform.position);
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);

            transform.DOMoveZ((transform.position.z + 2), 0.15f, false);
            canJump = Time.time + timeBeforeNextJump;
            //transform.position = (transform.position + new Vector3(0, 0, 2));
        }

    }




    private void isItHopping()
    {
        isHopping = false;
        Debug.Log(isHopping);
    }
}
