using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Hardware;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    
    public Boolean hit = false;
    public float moveSpeed = 5;
    public float deadZone = -20;
    public Boolean upDown = true;
   
    private float upDownSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(hit == false){
            Debug.Log("true");
        }
        

        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        /*range = birbPos.position.x -transform.position.x;  
        timer+= Time.deltaTime;
        if(timer < 3){
            upDown = true;
            Debug.Log("Shifting");
            Debug.Log(timer);
            shiftPipe();
            
        }
        if(timer >3 && timer <6){
            upDown = false;
            shiftPipe();
            //timer = 0;
        }
        */


        
        //If the pipe is behind birb --> change tag of pipe to untagged
        //This then means that the pipe behind birb will not be destroyed cuz that
        //pipe's tag will be changed; looks like the changes (destroy, changeing tags etc)
        //always apply to the first object in the heirarchy --> e.g. that pipe was the first
        //to pop out
        

        if(transform.position.x < Weapon.Instance.firePoint.position.x){
            //This is: If pipe is behind FirePoint, it's tag is changed to avoid being targeted
            //and destroyed
            transform.gameObject.tag = "Untagged"; //gameObject has to be lower case? (Findout)
       }

        if (transform.position.x < deadZone){
            Debug.Log("Pipe Destroyed");
            Destroy(gameObject);
        }

       

        
    }
    public void gotHit(){
        Debug.Log("Got hit!");
        Destroy(GameObject.FindWithTag("Pipe"));
       
    }

    public void shiftPipe(){
        if (upDown == true){
            transform.position += (Vector3.up *upDownSpeed) * Time.deltaTime;
            //upDown =false;
        }
         if (upDown == false){
            transform.position += (Vector3.down *upDownSpeed) * Time.deltaTime;
            //upDown =true;
        }
        
    }
}
