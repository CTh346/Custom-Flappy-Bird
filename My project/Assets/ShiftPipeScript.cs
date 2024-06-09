using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TopPipeScript : MonoBehaviour
{

    public Transform birbPos;
    public Transform bottomPipePos;
    //public GameObject logicManager;
    public LogicScript logicScript;
    //private float range = 0;
    private float upDownSpeed = 6;
    private float timer = 0;
    private int difficutlyStep = 1;

    

    // Start is called before the first frame update
    void Start()
    {
       //logicManager = GameObject.FindGameObjectWithTag("Logic");
       
       //logicManager.GetComponent<LogicScript>();
      /* if(logicManager.GetComponent<LogicScript>() == null){
        Debug.Log("Component Not Found");
       }
       */

       logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
       
       
        
        //birbPos = GameObject.FindWithTag("RedBird").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //range = birbPos.position.x -transform.position.x;  
        if(logicScript.playerScore == 20 * difficutlyStep){
            difficutlyStep +=1;
            upDownSpeed += 2;
            Debug.Log(upDownSpeed);

        }

        

       

        timer+= Time.deltaTime;
        if(timer >2 && timer < 5){ //Delay the shifting by "2 units"; makes it hard to react to
            //upDown = true;
            //Debug.Log("Shifting");
           // Debug.Log(timer);
            shiftBottomPipe();
            
        }
        if(timer >2 && timer <5){
            //upDown = false;
            shiftTopPipe();
            //timer = 0;
        }
        
        
    }

    public void shiftTopPipe(){

        transform.position += (Vector3.down *upDownSpeed) * Time.deltaTime;
        
    }
    public void shiftBottomPipe(){
       
        bottomPipePos.position += (Vector3.up *upDownSpeed) * Time.deltaTime;
    }
    private void OnCollisionEnter2D (Collision2D collision){
        Debug.Log(collision.gameObject.name);
    }
}
