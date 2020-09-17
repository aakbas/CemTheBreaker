using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float screenWitdhInUnits= 16f;
    float mousePosInUnits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      mousePosInUnits=Input.mousePosition.x / Screen.width * screenWitdhInUnits;        
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos .x= Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }





}
