using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfigSO currentWave;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetwweenWaves = 0f;
    [SerializeField] bool isLooping;
 
    void Start()
    {
        StartCoroutine( SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartWapoint().position,
                                Quaternion.Euler(0,0,180), //identity rotationda de�i�iklik olmas�n, eular d�n�� y�n�n� biz verelim olsun
                                transform); // enemy spawner�n i�inde sawpn olsunlar child olarak 

                    yield return new WaitForSecondsRealtime(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSecondsRealtime(timeBetwweenWaves);
            }
        } while (isLooping);
       
    }

    
  

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

}
