using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float currentSpeed = 1f;
    private GameObject _currentTarget;


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        UpdateAnimationState();
    }

    public void UpdateAnimationState()
    {
        if (!_currentTarget) GetComponent<Animator>().SetBool("Is Attacking", false);
    }

    public void SetMovmentSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("Is Attacking", true);
        _currentTarget = target;
    }

    public void Stikecurrenttarget(float damege)
    {
        if (!_currentTarget) return;
        Health health = _currentTarget.GetComponent<Health>();
        if (health)
        {
            health.Dealdamage(damege);
        }
    }
}