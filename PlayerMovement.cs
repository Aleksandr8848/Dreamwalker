using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rollSpeed; // �������� ��������
    public Rigidbody2D rb;
    private Vector2 moveDrection;
    private bool isRolling; // ����, �����������, ����������� �� �������
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {
        if (!isRolling) // ��������� ������ ���� �� ����������� �������
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
        // ��������� ������� �������� ����� ���������
        Vector2 prevVelocity = rb.velocity;
        // ������������� ����� �������� ��� ��������
        rb.velocity = moveDrection * rollSpeed;
        // ���� ��������� �����
        yield return new WaitForSeconds(0.5f); // ����� ��������
        // ���������� ���������� �������� ����� ��������
        rb.velocity = prevVelocity;
        isRolling = false;
    }
}