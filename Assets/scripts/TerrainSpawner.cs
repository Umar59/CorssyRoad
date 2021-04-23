using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainSpawner : MonoBehaviour
{
    public int minZ = 2;
    public int lineAhead = 40;
    public int lineBehind = 20;

    public GameObject[] linePrefabs;
    public GameObject coins;
    public Transform terrainHolder;
    private Dictionary<int, GameObject> lines;

    private GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lines = new Dictionary<int, GameObject>();
        
    }

    public void Update()
    {
        var playerZ = (int) player.transform.position.z;

        for (var z = Mathf.Max(minZ, playerZ - lineBehind); z <= playerZ + lineAhead; z +=1)
        {
            if (!lines.ContainsKey(z))
            {
                var line = (GameObject) Instantiate(
                    linePrefabs[Random.Range(0, linePrefabs.Length)],
                    new Vector3(0, 0, z),
                    Quaternion.Euler(0, 0, 0),
                    terrainHolder
                   
                );
                    Debug.Log("terrain");
                lines.Add(z, line);
                
                GameObject coin;
                int x = Random.Range(0, 2);
                if (x == 1)
                {
                    coin = (GameObject) Instantiate(coins, lines[z].transform, true);
                    int randX = Random.Range(-5, 5);
                    coin.transform.position = new Vector3(randX, 0f, z);
                    Debug.Log("coin");
                }


                
            }
        }

        // Remove lines based on player position.
        foreach (var line in new List<GameObject>(lines.Values))
        {
            var lineZ = line.transform.position.z;
            if (lineZ < playerZ - lineBehind)
            {
                lines.Remove((int) lineZ);
                Destroy(line);
            }
        }
    }

    public void Reset()
    {
        if (lines != null)
        {
            foreach (var line in new List<GameObject>(lines.Values))
            {
                Destroy(line);
            }

            Start();
        }
    }
}