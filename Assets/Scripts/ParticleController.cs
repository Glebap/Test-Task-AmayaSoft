using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    public ParticleSystem particleStars;
    
    public void SpawnParticles(Vector2 spawnPosition)
    {
        particleStars.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, 0f);
        particleStars.Play();
    }
}
