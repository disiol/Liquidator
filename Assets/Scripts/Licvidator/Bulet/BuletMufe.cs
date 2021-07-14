using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuletMufe : MonoBehaviour
{
    public float buletSpead = 0.5f;
      


    // Update is called once per frame
    void Update()
    {
                   
        if(transform.position.y > 3f){
            Destroy(gameObject);
        }
      
        transform.position += new Vector3 (0, buletSpead * Time.deltaTime, 0);

        if(GameControl.instance.gameOver){
            Destroy(gameObject);
        }

       

    }
     void  OnTriggerEnter2D (Collider2D other){
             Debug.Log("other.gameObject.tag = " +  other.gameObject.tag);

        if(other.gameObject.tag == "Ball"){
            GameControl.instance.LiicvidatorScored(true);
             Destroy(gameObject);
            
        }
    }

    
}
