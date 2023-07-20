using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BattelMoveset : MonoBehaviour
{
    public float radius = 1.5f; // ������ �� �������
    public float pauseTime = 0.5f; // ����� � ��������
    public float knockback = 3f; // ������������
    private bool isCharging = false;
    private float chargeTime = 0f;
    private GameObject target;
    private enum WeaponType
    {
        Bat,
        Gloves
    }
    private WeaponType currentWeapon = WeaponType.Bat;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            target = FindNearestEnemy();
        }
        // ������������ ������ � ������� ��������� �������� ����
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0f)
        {
            currentWeapon = WeaponType.Gloves;
        }
        else if (scrollWheel < 0f)
        {
            currentWeapon = WeaponType.Bat;
        }
        if (currentWeapon == WeaponType.Bat)
        {
            HandleBatAttacks();
        }
        else if (currentWeapon == WeaponType.Gloves)
        {
            HandleGloveAttacks();
        }
    }
    private void HandleBatAttacks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isCharging)
            {
                DoChargedAttack();
            }
            else if (Input.GetKey(KeyCode.LeftShift) && target != null)
            {
                ThrowBall();
            }
            else
            {
                DoLightAttack();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (isCharging)
            {
                DoChargedAttack();
            }
            else if (Input.GetKey(KeyCode.LeftShift) && target != null)
            {
                ThrowBoomerang();
            }
            else
            {
                isCharging = true;
                chargeTime = Time.time;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (isCharging)
            {
                DoChargedAttack();
                isCharging = false;
                chargeTime = 0f;
            }
        }
    }
    private void HandleGloveAttacks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoPunch();
        }
        if (Input.GetMouseButtonDown(1))
        {
            DoKick();
        }
        if (Input.GetMouseButton(0))
        {
            DoQuickCombo();
        }
        if (Input.GetMouseButton(1))
        {
            DoPowerfulCombo();
        }
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && target != null)
        {
            DoHookPull();
        }
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftShift) && target != null)
        {
            DoGrabAndAttack();
        }
    }
    private void DoLightAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D enemy in hitEnemies)
        {
            // ��������� �������� �����
            enemy.GetComponent<Rigidbody2D>().AddForce((enemy.transform.position - transform.position) * knockback, ForceMode2D.Impulse);
            // ������� ���� �����
            enemy.GetComponent<EnemyBehavior>().TakeDamage(10);
        }
    }
    private void DoChargedAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D enemy in hitEnemies)
        {
            // ��������� �������� �����
            enemy.GetComponent<Rigidbody2D>().AddForce((enemy.transform.position - transform.position) * knockback * 2, ForceMode2D.Impulse);
            // ������� ���� �����
            enemy.GetComponent<EnemyBehavior>().TakeDamage(20);
        }
    }
    private void ThrowBall()
    {
        GameObject ball = Instantiate(Resources.Load("Ball")) as GameObject;
        ball.transform.position = transform.position;
        ball.GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position).normalized * 10, ForceMode2D.Impulse);
    }
    private void ThrowBoomerang()
    {
        GameObject boomerang = Instantiate(Resources.Load("Boomerang")) as GameObject;
        boomerang.transform.position = transform.position;
        boomerang.GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position).normalized * 10, ForceMode2D.Impulse);
    }
    private void DoPunch()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D enemy in hitEnemies)
        {
            // ��������� �������� �����
            enemy.GetComponent<Rigidbody2D>().AddForce((enemy.transform.position - transform.position) * knockback, ForceMode2D.Impulse);
            // ������� ���� �����
            enemy.GetComponent<EnemyBehavior>().TakeDamage(10);
        }
    }
    private void DoKick()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D enemy in hitEnemies)
        {
            // ��������� �������� �����
            enemy.GetComponent<Rigidbody2D>().AddForce((enemy.transform.position - transform.position) * knockback * 2, ForceMode2D.Impulse);
            // ������� ���� �����
            enemy.GetComponent<EnemyBehavior>().TakeDamage(20);
        }
    }
    private void DoQuickCombo()
    {
        // ���������� ����� ������� ������
    }
    private void DoPowerfulCombo()
    {
        // ���������� ����� ������ ������
    }
    private void DoHookPull()
    {
        // ���������� ������������ � ������� �����
    }
    private void DoGrabAndAttack()
    {
        // ���������� ������� � ����������� ���� �����
    }
    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;
    }
}
