using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{

    private Zone slowdownZonePrefab;
    private Zone deathZonePrefab;

    private List<Zone> allZonesInScene = new();

    private float xAxisSpawnRange;
    private float zAxisSpawnRange;



    public void Init(Zone slowdownZonePrefab,Zone deathZonePrefab, float xAxisSpawnRange, float zAxisSpawnRange)
    {
        this.slowdownZonePrefab = slowdownZonePrefab;
        this.deathZonePrefab = deathZonePrefab;
        this.xAxisSpawnRange = xAxisSpawnRange;
        this.zAxisSpawnRange = zAxisSpawnRange;
    }

    public void SpawnZones()
    {
        for(int i = 0; i < 3; i++)
        {
            allZonesInScene.Add(Instantiate(slowdownZonePrefab, GetRandomPosition(), Quaternion.identity));
            CheckAndChangeZonesPosition();
        }
        for (int i = 0; i < 2; i++)
        {
            allZonesInScene.Add(Instantiate(deathZonePrefab, GetRandomPosition(), Quaternion.identity));
            CheckAndChangeZonesPosition();
        }

    }

    private void CheckAndChangeZonesPosition()
    {

        if (allZonesInScene.Count == 1)
            return;

        bool allZonesHasCorrectPositions = false;

        while (!allZonesHasCorrectPositions)
        {
            allZonesInScene[allZonesInScene.Count - 1].transform.position = GetRandomPosition();

            for (int i = 0; i < allZonesInScene.Count - 1; i++)
            {
                if (Vector3.Distance(allZonesInScene[allZonesInScene.Count - 1].transform.position, allZonesInScene[i].transform.position) < 3)
                {
                    allZonesHasCorrectPositions = false;
                    //break;
                }
                else
                {
                    allZonesHasCorrectPositions = true;
                }
            }
        }
    }


    private Vector3 GetRandomPosition()
    {
        Vector3 result = new Vector3(Random.Range(-xAxisSpawnRange, xAxisSpawnRange), 0, Random.Range(-zAxisSpawnRange, zAxisSpawnRange));
        return result;
    }
}
