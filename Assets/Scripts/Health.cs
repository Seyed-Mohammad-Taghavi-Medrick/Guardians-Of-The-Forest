using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private GameObject deathVFX;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Dealdamage(float damage)
    {
        health -= damage;

        StartCoroutine(ChangeColorCoroutine());
        
        if (health <= 0)
        {
            TriggerDestroy();
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangeColorCoroutine()
    {
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.25f);
        
        _spriteRenderer.color = Color.white;
    }
    
    private void TriggerDestroy()
    {
        if (!deathVFX)
        {
            return;
        }

        GameObject VFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(VFXObject, 1f);
    }
}