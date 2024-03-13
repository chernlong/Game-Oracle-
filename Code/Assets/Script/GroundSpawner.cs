using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject wallTile;
    Vector3 nextSpawnpoint;
    public void SpawnTile(bool spawnItem)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnpoint, Quaternion.identity);
        nextSpawnpoint = temp.transform.GetChild(1).transform.position;
        if (spawnItem)
        {
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }
    void Start()
    {//ทางว่างๆจุดเริ่มต้น

        for (int i = 0; i < 15; i++)
        {
            if (i < 2)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }

        }
    }
}
