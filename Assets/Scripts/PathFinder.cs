using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;

    List<Transform> wayPoints;
    int wayPointIndex = 0;


    public void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    public void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        wayPoints = waveConfig.GetWaypointsTransforms();
        transform.position = wayPoints[wayPointIndex].position;
    }

    public void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if(wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPos = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
            if(transform.position== targetPos)
            {
                wayPointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
