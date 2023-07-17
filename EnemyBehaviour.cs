using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health = 100; // �������� ����������

    private Transform player; // ������ �� ������
    private float moveSpeed = 2f; // �������� �������� ����������

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ �� ����
    }

    void Update()
    {
        // ������� ���������� � ������� ������
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // ���������, ���� ��������� ������ ������, �� ������� ���� ������
        if (Vector2.Distance(transform.position, player.position) < 0.5f)
        {
            player.GetComponent<PlayerStatus>().TakeDamage(10); // ��������������, ��� � ������ ���� ������ PlayerHealth ��� ������������ ��� �������� � ��������� �����
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ������ ������ ����������, ��������, ���������� �������� ����������� ������
        GameManager.instance.EnemyKilled();

        Destroy(gameObject);
    }
}