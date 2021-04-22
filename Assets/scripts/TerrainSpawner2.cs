using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainSpawner2 : MonoBehaviour
{

    [SerializeField] private int maxChunks;
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    ObjectPooler _objectPooler;

    private Vector3 currentPosition = new Vector3(0f, 0f, 0f);
    private List<GameObject> currentTerrain = new List<GameObject>();

    void Start()
    {
        //_objectPooler = ObjectPooler.Instance;
        for (int i = 0; i < maxChunks; i++)
        {
            TerrainSpawn(true, Vector3.zero);
        }
        //maxChunks = currentTerrain.Count;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
           // TerrainSpawn(false);

        }

    }
    public void TerrainSpawn(bool isStart, Vector3 playerPosition)
    {
      // _objectPooler.SpawnFromPool("road", currentPosition, Quaternion.identity);
      if (currentPosition.z - playerPosition.z < minDistanceFromPlayer )
      {
                  int whichTerrainToSpawn = Random.Range(0, terrainDatas.Count);
                  int terrainMaxInRow = Random.Range(1, terrainDatas[whichTerrainToSpawn].maxChunksAtTime);
                  for (int i = 0; i < terrainMaxInRow; i++)
                  {
                      GameObject terrains = Instantiate(terrainDatas[whichTerrainToSpawn].possibleTerrain[Random.Range(0, terrainDatas[whichTerrainToSpawn].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                      currentTerrain.Add(terrains);
                      if (!isStart)
                      {
                          if (currentTerrain.Count > maxChunks)
                          {
          
                              Destroy(currentTerrain[0]);
                              currentTerrain.RemoveAt(0);
                          }
                      }
          
                      currentPosition.z += 2;
          
          
                  }
      }
    }
}

