using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrace : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private List<string> ground;
    //private ParticleSystem ps;

    void Start()
    {
        //ps = GetComponent<ParticleSystem>();    // Get the particle system on your GameObject once
        //var emission = ps.emission;                 // Get the current emission module
        //Debug.Log(emission.GetType().FullName);
        //emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ground.Contains(collision.gameObject.tag))
        {
            var main = particle.main;
            main.loop = false;
        }
    }
}
