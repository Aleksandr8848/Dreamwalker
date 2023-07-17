using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rollSpeed; // скорость переката
    public Rigidbody2D rb;
    private Vector2 moveDrection;
    private bool isRolling; // флаг, указывающий, выполняется ли перекат
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {
        if (!isRolling) // двигаться только если не выполняется перекат
        {
            Move();
        }
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDrection = new Vector2(moveX, moveY).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Roll();
        }
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDrection.x * moveSpeed, moveDrection.y * moveSpeed);
    }
    void Roll()
    {
        if (!isRolling)
        {
            StartCoroutine(RollCoroutine());
        }
    }
    IEnumerator RollCoroutine()
    {
        isRolling = true;
        // сохраняем текущую скорость перед перекатом
        Vector2 prevVelocity = rb.velocity;
        // устанавливаем новую скорость для переката
        rb.velocity = moveDrection * rollSpeed;
        // ждем некоторое время
        yield return new WaitForSeconds(0.5f); // время переката
        // возвращаем предыдущую скорость после переката
        rb.velocity = prevVelocity;
        isRolling = false;
    }
}