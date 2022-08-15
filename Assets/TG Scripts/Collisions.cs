using UnityEngine;

public class Collisions : MonoBehaviour
{
    //Initiliase the audio clips for when objects collide
    [SerializeField] private AudioClip Pop;
    [SerializeField] private AudioClip Blop;
    [SerializeField] private AudioClip Clink;
    [SerializeField] ParticleSystem targetParticles;
    [SerializeField] ParticleSystem enemyParticles;
    [SerializeField] ParticleSystem hazardParticles;
    private AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Register collisions depending on the tags for the objects.
        //Play audio clip for each type of sphere. (AtPoint instead of OneShot because there are multiple different types of audio clips to play)
        if (collision.collider.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "Target Sphere")
        {
            ScoreManager.instance.AddPoint();
            AudioSource.PlayClipAtPoint(Blop, transform.position, 0.5f);
            targetParticles.Play();
            Destroy(collision.gameObject);
            //Debug.Log("Hit!");
        }

        else if (collision.collider.tag ==  "Hazard Sphere")
        {
            ScoreManager.instance.HazardPoint();
            AudioSource.PlayClipAtPoint(Clink, transform.position, 0.5f);
            hazardParticles.Play();
            Destroy(collision.gameObject);
            //Debug.Log("Hit!");
        }    
        else if (collision.collider.tag == "Enemy")
        {
            ScoreManager.instance.AddPoint();
            AudioSource.PlayClipAtPoint(Blop, transform.position, 0.5f);
            targetParticles.Play();
            Destroy(collision.gameObject);
            //Debug.Log("Hit!");
        }

       // If the object hits the Wall object, destroy it
            
            
    }
}
