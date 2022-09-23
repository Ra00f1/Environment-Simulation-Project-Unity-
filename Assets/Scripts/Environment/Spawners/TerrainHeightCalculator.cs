using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHeightCalculator : MonoBehaviour
{
    float A;
    public GameObject Player;

    public GameObject Tree;
    void Update()
    {
        A = Player.transform.position.y;
    }

    public void SpawnTree(int mapchunksize, float height)
    {
        //Instantiate(Tree, new Vector3(Random.RandomRange(gameObject.transform.position.x - mapchunksize, gameObject.transform.position.x + mapchunksize), height, Random.RandomRange(gameObject.transform.position.z - mapchunksize, gameObject.transform.position.z + mapchunksize)), Quaternion.identity);
    }
}
