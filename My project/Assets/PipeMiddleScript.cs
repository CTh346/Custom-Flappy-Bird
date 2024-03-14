using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    public GameObject obj; 
    

    private bool t;
    




    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")
        .GetComponent<LogicScript>();

        obj = GameObject.FindGameObjectWithTag("RedBird");
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       t = obj.GetComponent<BirdScript>().birdIsAlive;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.gameObject.layer == 3 && t){
             logic.addScore(1);
        } 
       
    }
   
}
