using UnityEngine;

public class Collisions : MonoBehaviour
{
    //Initiliase the audio clips for when objects collide
    /*[SerializeField] private AudioClip Pop;
    [SerializeField] private AudioClip Blop;
    [SerializeField] private AudioClip Clink;
    [SerializeField] ParticleSystem targetParticles;
    [SerializeField] ParticleSystem enemyParticles;
    [SerializeField] ParticleSystem hazardParticles;
    private AudioSource audiosource;
    */
    //public GameObject UIScoreScript;

    public GameObject ScoreManagerScript;

    private void Start()
    {
        //audiosource = GetComponent<AudioSource>();
    }
    
    public void DiamondScore()
    {
        
      // UIScoreScript.GetComponent<ScoreManager>().AddDiamondPoint();
      print("Diamond");
    }

    public void EmeraldScore()
    {
        print("Emerald");
       // UIScoreScript.GetComponent<ScoreManager>().AddEmeraldPoint();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Register collisions depending on the tags for the objects.
        //Play audio clip for each type of sphere. (AtPoint instead of OneShot because there are multiple different types of audio clips to play)
        if (collision.collider.tag == "Diamond")
        {
            DiamondScore();
            ScoreManagerScript.GetComponent<ScoreManager>().AddDiamondPoint();
            ScoreManagerScript.GetComponent<ScoreManager>().WriteString();
        }
        else if (collision.collider.tag == "Emerald")
        {
            EmeraldScore();   
            ScoreManagerScript.GetComponent<ScoreManager>().AddEmeraldPoint();
            ScoreManagerScript.GetComponent<ScoreManager>().WriteString();
        }
    }
}
