using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType EnemyType;
    public int DamageValue = 5;
    public int MoveSpeed = 10;
    public bool ReadyToLaunch, Moving;
    void Start()
    {
    }

    void Update()
    {
        if (ReadyToLaunch && !Moving)
        {
            Launch();
        }
        if (Moving)
        {
            Move();
        }
    }

    public void Launch()
    {
        GameManager.Instance.ActiveEnemiesCount++;
        Moving = true;
    }

    public void Move()
    {
        // Desired movement according to enemy type
        transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            GameManager.Instance.ReduceDoorHealth(DamageValue);
            Reset();
        }
    }

    public void Reset()
    {
        GameManager.Instance.ActiveEnemiesCount--;
        transform.position = GameManager.Instance.EnemyPrefab.transform.position;
        ReadyToLaunch = false;
        Moving = false;
    }
}

public enum EnemyType
{
    Normal = 0, Zigzag
}
