using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform hero;
    public float vateBeforeFireSeconds;
    public int maxBuletOnzeSrin; // max 20

    void Start()
    {
        //StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (!GameControl.instance.gameOver)
        {
            yield return new WaitForSeconds(vateBeforeFireSeconds);
            
        }
    }

    private void OnMouseUp()
    {
        //TODO без ограничение для детей
        int SpawnBulletCaunt = FindObjectsOfType<BuletMufe>().Length;
        Debug.Log("SpawnBulletCaunt = " + SpawnBulletCaunt);

        if (SpawnBulletCaunt < maxBuletOnzeSrin)
        {
            new WaitForSeconds(vateBeforeFireSeconds);
            Instantiate(bullet, new Vector2(hero.position.x, hero.position.y + 1f), Quaternion.identity);
        }
    }
}