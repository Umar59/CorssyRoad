using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterPlotSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject plotPrefabs;
    [SerializeField] private List<GameObject> plotPrefabs;
    [SerializeField] private int leftSpawn = -12;
    [SerializeField] private int rightSpawn = 12;
    
    private float _plotSpeed;
    private float _spawnInterval;
    private float _plotScaleX;

    private int direction;
    
    private void Start()
    {
        _spawnInterval = Random.Range(2.5f, 4f);

        direction = Random.Range(0, 2);
        direction = direction == 0 ? leftSpawn : rightSpawn;
        
        InvokeRepeating("SpawnPlot", 0f,_spawnInterval);
    }


    private void SpawnPlot()
    {
        
        _plotSpeed = Random.Range(10f,15f);
        _plotScaleX = Random.Range(0.5f, 2f);
        
        var plot = Instantiate(plotPrefabs[Random.Range(1, plotPrefabs.Count)], transform, true);
        
        plot.transform.position = new Vector3(direction, -0.5f, transform.position.z);
        if (direction == leftSpawn)
        {
            plot.transform.rotation = Quaternion.Inverse(plot.transform.rotation);
        }

        plot.transform.DOScaleX(_plotScaleX, 0f);
        plot.transform.DOMoveX(-direction, _plotSpeed).OnComplete(()=>Enable(plot));;
    }
    
    private void Enable(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    
}
