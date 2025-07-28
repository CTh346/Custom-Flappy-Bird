using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    public BirdScript Birb; 
    

    private bool birdAlive;
    




    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")
        .GetComponent<LogicScript>();

        Birb = GameObject.FindGameObjectWithTag("RedBird").GetComponent<BirdScript>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Constantly checks if bird is alive from the bird script
       birdAlive = Birb.GetComponent<BirdScript>().birdIsAlive; 
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.gameObject.layer == 3 && birdAlive){
             logic.addScore(1);
             logic.checkTopScore();
             
        } 
        
       
    }
   
}
