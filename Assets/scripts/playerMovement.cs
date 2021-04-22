using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
   
  
    [SerializeField] private float timeBeforeNextJump = 1f;
    private float canJump = 0f;
    private bool isHopping;
    
    
    private Animator animator;
    public Swipe swipes;
    private Vector2 direction2;
  //  public TerrainSpawner _terrainSpawner;
    private AudioSource playerSound;
    
    public int lefLimit = -4;
    public int rightLimit = 4;

    public delegate void AddScore(int score);
    public event AddScore onAddScore;
    
    public delegate void AddMoney(int money);
    public event AddMoney onAddMoney;
    
    public delegate void GameOver();
    public event GameOver gameOver;


    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip moneySound;
    [SerializeField]
    private AudioClip waterDeathSound;
    [SerializeField]
    private AudioClip carDeathSound;
    
    
    void Start()
    {
        playerSound = GetComponent<AudioSource>();
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
                   float xDifference = 0;
                   if (transform.position.x %1 != 0)
                   {
                       xDifference = Mathf.Round(transform.position.x) - transform.position.x;
                   }
                   Move(new Vector3(xDifference,  0, 1), new Vector3(0, 0, 0));
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
                Move(new Vector3(xDifference,  0, 1), new Vector3(0, 0, 0));
            }
            else if (swipes.swipeDown && !isHopping)
            {
                Move(new Vector3(0,  0,  -1), new Vector3(0, 180, 0));
            }
            else if (swipes.swipeLeft && !isHopping)
            {
                Move(new Vector3(- 1, 0, 0), new Vector3(0, -90, 0));
            }
            else if (swipes.swipeRight && !isHopping)
            {
                Move(new Vector3( 1, 0, 0), new Vector3(0, 90, 0));
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
        Ray ray = new Ray(transform.position, direction);
        Vector3 nextPosition = transform.position + direction;
        RaycastHit hit;
        Physics.Raycast(ray); 
        if (Physics.Raycast(ray, out hit, 1f))
        {   
           
            if (hit.collider.CompareTag("Obstacle"))
            { 
                return ;
            }
        }

        if (nextPosition.x >= lefLimit || nextPosition.x <= rightLimit)
        {
          
            return;
        }
        playerSound.PlayOneShot(jumpSound);
        isHopping = true;
        animator.SetTrigger("hop");
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.15f);
        transform.DORotate(rotation, 0.15f, RotateMode.Fast);
        transform.DOMove( transform.position + direction, 0.15f, false);
        //_terrainSpawner.TerrainSpawn(false, transform.position);
        canJump = Time.time + timeBeforeNextJump;
        onAddScore.Invoke((int)nextPosition.z);
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log("coin");
            other.gameObject.SetActive(false);
            onAddMoney.Invoke(1);
            playerSound.PlayOneShot(moneySound);
        }
        if (other.gameObject.CompareTag("Car"))
        {
            Debug.Log("Hui");
            gameOver.Invoke();
            transform.DOScaleY(0.5f, 0f);
            playerSound.PlayOneShot(carDeathSound);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        var gameObject = other.gameObject;
        if (gameObject.CompareTag("Water"))
        {
            WaterDeath();
        }
    }

    private void WaterDeath()
    {
        gameOver.Invoke();
        transform.DOMoveY(-1, 0.6f);
        transform.DOShakeScale(0.5f, Vector3.one * 3, 1, 0, true).OnComplete(() => this.gameObject.SetActive(false));
        playerSound.PlayOneShot(waterDeathSound);
    }

    private void isItHopping()
    {
        isHopping = false;

    }
}
