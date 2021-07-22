using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Target : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int points = 1;

    protected abstract void DestroyFX();

    private void AddPoints()
    {
        GameManager.Instance.Score += points;
    }
    
    private void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            AddPoints();
            DestroyFX();
        }
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sharp"))
        {
            Damage(other.GetComponent<Sharp>().DamageAmount);
        }
    }
}
