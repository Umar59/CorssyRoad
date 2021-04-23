using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> carPrefabs;

    [SerializeField] private int leftSpawn = -12;
    [SerializeField] private int rightSpawn = 12;

    [SerializeField] private float CarSpeedMin, CarSpeedMax;
    private float carSpeed;
    private float _spawnInterval;

    private int direction;

    private GameObject _resultCar;
    
    

    private void Start()
    {
        carSpeed = Random.Range(CarSpeedMin,CarSpeedMax);
        _spawnInterval = Random.Range(4f, 5f);

        direction = Random.Range(0, 2);
        direction = direction == 0 ? leftSpawn : rightSpawn;

        _resultCar = carPrefabs[Random.Range(0, carPrefabs.Count)];
        InvokeRepeating("SpawnCar", 0f,_spawnInterval);
    }

    private void SpawnCar()
    {
        var car = Instantiate(_resultCar, transform, true);
        
        car.transform.position = new Vector3(direction, 0f, transform.position.z);
        if (direction == leftSpawn)
        {
            car.transform.rotation = Quaternion.Inverse(car.transform.rotation);
        }
        
        
        car.transform.DOMoveX(-direction, carSpeed).OnComplete(()=>Enable(car));
    }

    private void Enable(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
