using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projetile, gun;
    private AttackerSpawner _myLaneSpawner;
    private Animator _animator;
    
    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsAttackerInTheLane())
        {
            _animator.SetBool("isAtacking",true);
           
        }
        else
        {
            _animator.SetBool("isAtacking" ,false);
          
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y )<= Mathf.Epsilon);


            if (isCloseEnough)
            {
                _myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInTheLane()
    {
        if (_myLaneSpawner == null)
        {
            return false;
        }
        
        if (_myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
            
    }


    public void Fire()
    {
        Instantiate(projetile, gun.transform.position, gun.transform.rotation);
    }
}