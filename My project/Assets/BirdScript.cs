using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class BirdScript : MonoBehaviour

{   
    public Rigidbody2D myRigidBody2d;
    public float flapStrenghth; 
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic")
        .GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            //May want to experiment with later
            myRigidBody2d.velocity = Vector2.up * flapStrenghth;
        }
    }
     private void OnCollisionEnter2D(Collision2D collision){
        logic.gameOver();
        birdIsAlive = false;
    }
}
