using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public int TreesToSpawn;
    public int treeSpawnChance = 20;
    private int temp;
    private int SpawnedTrees;

    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;
    public GameObject Tree;

    private void Start()
    {
        //Tree = Resources.Load<GameObject>("Tree Type0 04.prefab");
    }
    private void Update()
    {
        temp = Random.Range(0, 100);
    }

    public void Spawntree(Vector3 position)
    {
        if(SpawnedTrees <= TreesToSpawn)
        {
            if (temp < treeSpawnChance)
            {
                Instantiate(Tree, position, Quaternion.identity);
                SpawnedTrees++;
            }
        }
    }
}
