using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BollFall : MonoBehaviour
{
    private float fallSpead;
    

    private void Start()
    {
        fallSpead = GameControl.instance.fallSpead;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
            spedeFalenPlas(false);
        }

        transform.position -= new Vector3(0, fallSpead * Time.deltaTime, 0);

        if (GameControl.instance.gameOver)
        {
            Destroy(gameObject);
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("other.gameObject.tag = " + other.gameObject.tag);

        if (other.gameObject.tag == "Bullet")
        {
            spedeFalenPlas(true);
            GameControl.instance.bangSound.pitch = Random.Range(0.9f,1.1f);
            GameControl.instance.bangSound.Play();
            Destroy(gameObject);

        }
    }
    
    void spedeFalenPlas(bool flag)
    {
        fallSpead = GameControl.instance.fallSpead + 0.001f;
        GameControl.instance.fallSpead = fallSpead;
        GameControl.instance.LiicvidatorScored(flag);
    }
}