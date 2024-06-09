using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;



public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject pipePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = transform.right * speed;
    }

    void Update(){
        
    }
   void OnTriggerEnter2D(Collider2D hitInfo){
    
        PipeMoveScript pipe = pipePrefab.GetComponent<PipeMoveScript>();
        
        if(pipe != null){
            pipe.gotHit();
            Debug.Log(hitInfo.name);
           
        }
        if(pipe == null){
            //pipe.gotHit();
            Debug.Log("Nothing");
        }

        
        Destroy(gameObject);
   }
    
}
