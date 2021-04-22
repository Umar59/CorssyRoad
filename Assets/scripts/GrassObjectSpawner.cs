
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GrassObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> Tree;

    private void Start()
    {
        int countTrees = Random.Range(2, 6);

        for (int i = 0; i < countTrees; i++)
        {
            GameObject tree = Instantiate(Tree[Random.Range(0, Tree.Count)], transform, true);
            tree.transform.position = transform.position;
            
            int randX = Random.Range(-6, 6);
            tree.transform.position = new Vector3(randX, transform.position.y, transform.position.z);

        }

        for (int i = -12; i <= -6; i++)
        {
            GameObject tree = Instantiate(Tree[Random.Range(0, Tree.Count)], transform, true);
            tree.transform.position = transform.position;
            tree.transform.position = new Vector3(i, transform.position.y, transform.position.z);;
        }
        
        for (int i = 6; i < 12; i++)
        {
            GameObject tree = Instantiate(Tree[Random.Range(0, Tree.Count)], transform, true);
            tree.transform.position = transform.position;
            tree.transform.position = new Vector3(i, transform.position.y, transform.position.z);;
        }
        
    }
}
