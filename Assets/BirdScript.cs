using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool BirdIsAlive = true;
    public AudioSource wing;
    public AudioSource hit;
    public AudioSource die;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (wing == null)
        {
            wing = GetComponent<AudioSource>();
        }
        if (hit == null)
        {

            hit = gameObject.AddComponent<AudioSource>();
            hit.clip = Resources.Load<AudioClip>("hit"); 
        }
        if (die == null)
        {

            die = gameObject.AddComponent<AudioSource>();
            die.clip = Resources.Load<AudioClip>("die");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            wing.Play();
        }
        
        if ( transform.position.y > 7.6 || transform.position.y < -7.8 ||transform.position.x < -13 )
        {
            logic.gameOver();
            BirdIsAlive = false;
            die.Play();
        }
       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        BirdIsAlive = false;
        hit.Play();
    }
}
