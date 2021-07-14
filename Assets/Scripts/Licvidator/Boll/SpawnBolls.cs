using System.Collections;
using UnityEngine;

public class SpawnBolls : MonoBehaviour
{
   public GameObject bolls;
    void Start()
    {
        StartCoroutine (Spawn());
    }
    
    IEnumerator Spawn(){
        while(!GameControl.instance.gameOver){
            Instantiate (bolls , new Vector2 (Random.Range (-2.5f,2.5F), 5.5f),Quaternion.identity);
            yield return new WaitForSeconds (0.8f);
        }

       
    }
   
}
