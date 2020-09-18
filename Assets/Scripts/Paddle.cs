using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float screenWitdhInUnits= 16f;
    //Cached
    GameSession myGameSession;
    CemBall myCemBall;

    float mousePosInUnits;
    // Start is called before the first frame update
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        myCemBall = FindObjectOfType<CemBall>();
    }

    // Update is called once per frame
    void Update()
    {
           
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos .x= Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }


    private float GetXPos()
    {
        if (myGameSession.IsAutoPlayEnabled())
        {
            return myCemBall.transform.position.x;
        }

        else
        {
            return Input.mousePosition.x / Screen.width * screenWitdhInUnits;
        }
    }


}
