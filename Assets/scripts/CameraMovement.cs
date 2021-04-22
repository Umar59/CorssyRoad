using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float duration;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        DOTween.SetTweensCapacity(500, 50);
    }
    void Update()
    {
        transform.DOMove((target.position + new Vector3(0, 2, 0)), duration, false);
    }
}
