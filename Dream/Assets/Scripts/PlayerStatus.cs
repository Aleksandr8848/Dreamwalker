using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth = 100; // ������������ �������� ������
    public int currentHealth; // ������� �������� ������

    // ������ �������������� ������, ����� ��� ����, �������� � �.�.

    void Start()
    {
        currentHealth = maxHealth; // ������������� ������� �������� ������ ������������� �������� ��� ������
    }

    public void TakeDamage(int damage = 0)
    {
        currentHealth -= damage; // �������� ���� �� �������� ��������

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // ������ ������ ������, ��������, ������������ ������ ��� ����������� ������ ���������
    //    GameManager.instance.GameOver();
    }
}