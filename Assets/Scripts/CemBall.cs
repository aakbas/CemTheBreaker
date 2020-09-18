using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemBall : MonoBehaviour
{
    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float jumX;
    [SerializeField] float jumpY;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted=false;

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBallOnMouseClick();
        }
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
           myRigidBody.velocity = new Vector2(jumX, jumpY);
            hasStarted = true;
        }
     
            
    }

   private void LockBallToPaddle()
    {
        
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f,randomFactor), UnityEngine.Random.Range(0,randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
        }
    }




}
