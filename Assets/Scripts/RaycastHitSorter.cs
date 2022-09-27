using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitSorter : MonoBehaviour
{
    public List<Vector3> Positions;
    TreeSpawner treeSpawner;
    void Start()
    {
        treeSpawner = GameObject.FindObjectOfType<TreeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sort(Vector3 position)
    {
        if (Positions.Contains(position) == false)
        { 
            Positions.Add(position);
            treeSpawner.Spawntree(position);
        }
    }
}
