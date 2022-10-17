using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] bool useAI;

    [Header("Projectile")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("Fire")]
    [SerializeField] float firingRateVariance = 0;
    [SerializeField] float minFiringRate = 0.1f;
   
    
    
    [HideInInspector]public bool isFiring;

    Coroutine firingCo;
    AudioPlayer audioPlayer;


    public void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isFiring = useAI;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();

    }

    private void Fire()
    {
        if (isFiring && firingCo == null)
        {
           firingCo = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCo != null)
        {
            StopCoroutine(firingCo);
            firingCo  = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D projectileRB2d = instance.GetComponent<Rigidbody2D>();
            if(projectileRB2d != null)
            {
                projectileRB2d.velocity = transform.up * projectileSpeed ;
            }
            
            Destroy(instance, projectileLifeTime);

            float timeToNextProjectile = UnityEngine.Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);

        }
    }
}
