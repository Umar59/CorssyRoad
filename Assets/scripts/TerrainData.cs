using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Data", menuName = "Terrain Data")]
public class TerrainData : ScriptableObject
{
    public GameObject terrain;
    public int maxChunksAtTime;
                //max chunks of particular typa terrain can be spawned in a row
}
