using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    [SerializeField] ParticleSystem leadParticles;
    [SerializeField] GameObject[] creaturePrefabs;
    [SerializeField] float rotationSpeed = 25;

    List<Transform> creatureTransforms = new List<Transform>();
    ParticleSystem.Particle[] activeParticles;

    bool creaturesSpawned;

    IEnumerator Start()
    {
        activeParticles = new ParticleSystem.Particle[leadParticles.main.maxParticles];

        yield return new WaitUntil(ParticleSystemReady);

        int particlesAlive = leadParticles.GetParticles(activeParticles);
        for (int i = 0; i < particlesAlive; i++)
        {
            Transform creature = Instantiate(creaturePrefabs[Random.Range(0,creaturePrefabs.Length)], activeParticles[i].position, Quaternion.Euler(activeParticles[i].rotation3D), this.transform).transform;
            creatureTransforms.Add(creature);
        }

        creaturesSpawned = true;
    }

    void Update()
    {
        if(!creaturesSpawned) return;

        int particlesAlive = leadParticles.GetParticles(activeParticles);
        for (int i = 0; i < particlesAlive; i++)
        {
            creatureTransforms[i].position = activeParticles[i].position;
            creatureTransforms[i].rotation = Quaternion.RotateTowards(creatureTransforms[i].rotation, Quaternion.LookRotation(activeParticles[i].totalVelocity), rotationSpeed * Time.deltaTime);
        }
    }

    bool ParticleSystemReady()
    {
        if (!leadParticles.isEmitting && leadParticles.particleCount == leadParticles.main.maxParticles)
            return true;
        else
            return false;
    }
}