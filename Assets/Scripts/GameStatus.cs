using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    


    // Config params
   [Range(0.1f,10f)] [SerializeField] float gameSpeed =1f;
    [SerializeField] int pointPerBlockDestroyed=83;
    [SerializeField] Text scoreText ;
    //state variables
    [SerializeField] int currentScore=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
           
    }

    public void AddToScore()
    {
        currentScore += pointPerBlockDestroyed;
    }

}
