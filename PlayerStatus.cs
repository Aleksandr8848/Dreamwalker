using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth = 100; // ћаксимальное здоровье игрока
    public int currentHealth; // “екущее здоровье игрока

    // ƒругие характеристики игрока, такие как сила, скорость и т.д.

    void Start()
    {
        currentHealth = maxHealth; // ”станавливаем текущее здоровье равным максимальному здоровью при старте
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ¬ычитаем урон из текущего здоровь€

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Ћогика смерти игрока, например, перезагрузка уровн€ или отображение экрана поражени€
        GameManager.instance.GameOver();
    }
}