using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject shiftingPipe;
    public LogicScript logic;
    
    //Note for spawnrates: Want to reach the spawnrate for the shiftin pipes first before the 
    // seconde spawn/spawnrate of the regular pipes; i.e. spawn rate =4 & cutOffShift = 7
    private float spawnRate = 2.5f;
    private float timer = 0;
    public int heightOffset = 1; 

    private int regPipeCounter = 0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
        //timer = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(timer<spawnRate){
            timer += Time.deltaTime;
        }
        else if (timer > spawnRate && regPipeCounter <3){
            //timerSpecial += 1;
            spawnPipe();
            regPipeCounter +=1;
            Debug.Log(regPipeCounter);
            Debug.Log("Regular");
            Debug.Log(timer);
            timer = 0;
        }
        else {
            spawnShiftingPipe();
            Debug.Log("ShiftingPipe");
            Debug.Log(regPipeCounter);
            timer = 0;
            regPipeCounter = 0;
        }
        

        
    }
    void spawnPipe(){
        
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3 (transform.position.x, Random.Range(lowestPoint, highestPoint), 0), 
        transform.rotation);
    }
    void spawnShiftingPipe (){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(shiftingPipe, new Vector3 (transform.position.x, Random.Range(lowestPoint, highestPoint), 0), 
        transform.rotation);

    }
}
