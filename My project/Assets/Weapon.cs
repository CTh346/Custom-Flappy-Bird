using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public static Weapon Instance; //TODO: Look into this
    public  Transform firePoint;
    public GameObject projectilePrefab;
    public Transform bulletCountVisual;
    public BirdScript birdScript;
    private float timer = 0;
    private float reloadTime = 3; //Seems like its coolDownTime =  coolDownTime +1sec
    private int bulletsInStock = 3;

    public Image [] bulletVisual; //Note: Has to be public in order to be "seen" on Unity
    private int pointerForArray = 1;
    

//Look into this; this apparently makes this entire class a public and accessible class
//to all other classes. It is why I was able to access the firePoint object/variable's
//position
    void Awake() => Instance = this; 
    // Start is called before the first frame update
    void Start(){
        for(int i =0; i<bulletVisual.Length;i++){
            bulletVisual[i].enabled = true;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&&birdScript.birdIsAlive ==true){
            
            if (bulletsInStock ==3 || bulletsInStock > 0){
                Shoot();
                removebulletAmountVisual();
                bulletsInStock -= 1;

            }
            else if (bulletsInStock == 0){
                Debug.Log("Out of Ammo");
            }
        }

        if(bulletsInStock > 0 && bulletsInStock < 3){
            if(timer<reloadTime){
            timer +=Time.deltaTime; 
            }
            else if (timer > reloadTime){
                bulletsInStock += 1;
               Debug.Log("Reloaded");
               addbulletAmountVisual();
                timer = 0;
            }
       
        }
        else if(bulletsInStock == 0){
            //Reload time is doubled; time penalty for using up all bullets
           if(timer<(reloadTime *2)){
            timer +=Time.deltaTime; 
            }
            else if (timer > (reloadTime *2)){
                bulletsInStock += 1;
               Debug.Log("Reloaded 1st bullet");
               addbulletAmountVisual();
                timer = 0;
            }
        }
    }

    void Shoot(){
        Instantiate(projectilePrefab,firePoint.position, firePoint.rotation);
    }
    void addbulletAmountVisual(){
        //Use this method after Reload
        Image image = bulletVisual[(bulletVisual.Length+1)-pointerForArray]; 
        //Gives us the index just one above the current index if used appropriately, i.e. used after Reload
        //This is so that we can Reload the appropriate bullet, i.e. the one that was just used which 
        //is the one above the current index

        image.enabled = true;
        pointerForArray-=1;// Moving pointer up by 1
        
       

    }  
    void removebulletAmountVisual(){
        /*TODO: For visual, the problem is now I have to figure a way to go to the items in the 
        array and disable those from the end of array to start (DONE!!)
        */
        
        Image image = bulletVisual[bulletVisual.Length-pointerForArray]; //Gets last index
        image.enabled = false;
        
        if(pointerForArray ==bulletVisual.Length +1){
            pointerForArray-=1; //Moves pointer to index 0
            
        }
        else{
            pointerForArray +=1; //Moving pointer down by 1
        }
        

        
    } 
  
}

