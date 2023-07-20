using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBehavior : MonoBehaviour
{
    public int health = 100; // Здоровье противника

    private Transform player; // Ссылка на игрока
    private float moveSpeed = 2f; // Скорость движения противника
    public Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока по тегу
    }

    void Update()
    {
        // Двигаем противника в сторону игрока
       // rb.velocity = new Vector2(moveDrection.x * moveSpeed, moveDrection.y * moveSpeed);
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Проверяем, если противник достиг игрока, то наносим урон игроку
        if (Vector2.Distance(transform.position, player.position) < 0.5f)
        {
            player.GetComponent<PlayerStatus>().TakeDamage(10); // Предполагается, что у игрока есть скрипт PlayerHealth для отслеживания его здоровья и нанесения урона
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
        // Логика смерти противника, например, увеличение счетчика побежденных врагов
       // GameManager.instance.EnemyKilled();

        Destroy(gameObject);
    }
}