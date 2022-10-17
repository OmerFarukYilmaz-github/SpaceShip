using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0.2f;

    [SerializeField] Transform pathPrefab;
    [SerializeField] List<GameObject> enemyPrefabs;


    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetMoveSpeed()
    {
        return movementSpeed;
    }
    public Transform GetStartWapoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypointsTransforms()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach(Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue); // - BÝ DEÐER olmasýn diye
    }



}
