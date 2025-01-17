﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    


    // Config params
   [Range(0.1f,10f)] [SerializeField] float gameSpeed =1f;
    [SerializeField] int pointPerBlockDestroyed=83;
    [SerializeField] Text scoreText ;
    [SerializeField] bool isAutoPlayEnabled;
    //state variables
    [SerializeField] int currentScore=0;
    //Cached 
    


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

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

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
