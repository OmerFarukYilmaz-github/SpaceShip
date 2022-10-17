using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;


    [Header("Damage")]
    [SerializeField] AudioClip dmgClip;
    [SerializeField] [Range(0f, 1f)] float dmgVolume = 1f;

    public void PlayShootingClip()
    {
        PLayClip(shootClip, shootingVolume);
    }
    public void PlayDamageClip()
    {
        PLayClip( dmgClip,  dmgVolume);
    }

    void PLayClip(AudioClip clip, float vol)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, vol);
        }
    }

}
