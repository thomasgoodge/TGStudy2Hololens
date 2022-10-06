using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem ExplosionParticles;
    [SerializeField] ParticleSystem leftExplosionParticles;
    [SerializeField] ParticleSystem rightExplosionParticles;
    
    [SerializeField] public int score = 0;

    Vector3 currentVectorPosition;

    Vector3 leftColumn = new Vector3(-1f, -0.25f, 3.158f);
    Vector3 rightColumn = new Vector3(1f, -0.25f, 3.158f);

    public int Destroyed = 0;


 
    public void SpawnParticleSystem()


    {

        currentVectorPosition = this.transform.position;
        Instantiate(ExplosionParticles);
        
        ExplosionParticles.transform.position = currentVectorPosition;
        //Method that destroys the current game object. Used as a method called when object is focused on in the Hololens
        Instantiate(leftExplosionParticles);
        leftExplosionParticles.transform.position = leftColumn;


        Instantiate(rightExplosionParticles);
        rightExplosionParticles.transform.position = rightColumn;
        //explosionParticles.Play();

        Destroyed ++;
        

        
    }
}
