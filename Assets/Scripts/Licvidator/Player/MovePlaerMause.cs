using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlaerMause : MonoBehaviour
{
    [SerializeField] Transform hero;
    [SerializeField] float speed = 10f;

    void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.x = mousePos.x > 2.5f ? 2.5f : mousePos.x;
        mousePos.x = mousePos.x < -2.5f ? -2.5f : mousePos.x;
        if (!GameControl.instance.gameOver)
        {
            hero.position = Vector2.MoveTowards(hero.position,
                           new Vector2(mousePos.x, hero.position.y),
                           speed * Time.deltaTime);
        }
    }
}