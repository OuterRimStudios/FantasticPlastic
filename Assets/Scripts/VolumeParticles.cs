using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeParticles : MonoBehaviour
{
    public float speed;
    public float minOffset = .25f;
    public float maxOffset = 1f;

    List<float> offsets = new List<float>();

    ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[particleSystem.maxParticles];

        for(int i = 0; i < particles.Length; i++)
            offsets.Add(Random.Range(minOffset, maxOffset));
    }

    void Update()
    {
        int particleCount = particleSystem.GetParticles(particles);

        for(int i = 0; i < particleCount; i++)
            particles[i].position = Vector3.Lerp(particles[i].position, new Vector3(particles[i].position.x + Mathf.Sin(Time.time) * offsets[i], particles[i].position.y, particles[i].position.z), speed * Time.deltaTime);

        particleSystem.SetParticles(particles, particleCount);
    }
}
