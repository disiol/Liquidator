using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MovePlayerKebord : MonoBehaviour
{
    public Transform hero;

    public float playerSpeadKebord;
    public float boundary;

    void Update()
    {
        if (!GameControl.instance.gameOver)
        {
            Vector3 heroPosition = hero.position;
            heroPosition.x += Input.GetAxis("Horizontal") * playerSpeadKebord;

            // обновим позицию платформы
            transform.position = heroPosition;

            // проверка выхода за границы
            if (heroPosition.x < -boundary)
            {
                transform.position = new Vector3(-boundary, heroPosition.y, heroPosition.z);
            }

            if (heroPosition.x > boundary)
            {
                transform.position = new Vector3(boundary, heroPosition.y, heroPosition.z);
            }
        }
    }
}