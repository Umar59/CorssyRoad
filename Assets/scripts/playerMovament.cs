using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerMovament : MonoBehaviour
{

   

    private Animator animator;
    private bool isHopping;
  
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isHopping)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            Debug.Log(transform.position);

            transform.position = (transform.position + new Vector3(0, 0, 2));


        }
     
        
    }

    private void isItHopping()
    {
        isHopping = false;
    }
}
