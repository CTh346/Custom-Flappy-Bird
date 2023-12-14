using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BirdScript : MonoBehaviour
{   
    public Rigidbody2D myRigidBody2d;
    public float flapStrenghth; 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //May want to experiment with later
            myRigidBody2d.velocity = Vector2.up * flapStrenghth;
        }
    }
}
