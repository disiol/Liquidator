using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRotation : MonoBehaviour

{
    public bool isRightSide = true; //Если true, персонаж смотрит направо, а иначе — налево

    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Получение компонента, ответственного за физику объекта. Чтобы снизить нагрузку на игру, получение Rigidbody2D лучше вынести в метод Start().
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); //Получение направления движения

        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime); //Движение

        if ((moveX > 0f && !isRightSide) || (moveX < 0f && isRightSide))
        {
            //Если игрок начал двигаться в противоположную сторону
            if (moveX != 0f) //Если он не стоит
            {
                Spin(); //Вызов метода Spin()
            }
        }
    }

    //Он принимает направление движения и меняет масштаб по оси X. Умножив его на –1, можно «перевернуть» объект.
    void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }
}