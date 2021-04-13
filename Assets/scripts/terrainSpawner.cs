using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainSpawner : MonoBehaviour
{

    [SerializeField] private int maxChunks;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();

    private Vector3 currentPosition = new Vector3(0f, 0f, 0f);
    private List<GameObject> currentTerrain = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < maxChunks; i++)
        {
            TerrainSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TerrainSpawn();

        }

    }

    private void TerrainSpawn()
    {

        int whichTerrainToSpawn = Random.Range(0, terrainDatas.Count);
        int terrainMaxInRow = Random.Range(1, terrainDatas[whichTerrainToSpawn].maxChunksAtTime);
        for (int i = 0; i< terrainMaxInRow; i++)
        {
            GameObject terrains = Instantiate(terrainDatas[whichTerrainToSpawn].terrain, currentPosition, Quaternion.identity);

            currentTerrain.Add(terrains);
            if (currentTerrain.Count > maxChunks)
            {

                Destroy(currentTerrain[0]);
                currentTerrain.RemoveAt(0);
            }
            currentPosition.z += 2;


        }
     
    }
}
