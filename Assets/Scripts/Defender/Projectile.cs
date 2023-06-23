using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0f, 5f)] [SerializeField] float speedOfTheBullet;
    [Range(0f, 5f)] [SerializeField] private float speedOfTheRotate;
    [SerializeField] private float damage =100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speedOfTheBullet * Time.deltaTime, Space.World);
        transform.Rotate(0,0,-1*speedOfTheRotate);
        /*Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movmentDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);*/
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
        
        if (  attacker && health  )
        {
            /*
            otherCollider.GetComponent<SpriteRenderer>().color=Color.red;
            */
            /*otherCollider.GetComponent<SpriteRenderer>().color=Color.white;*/
            health.Dealdamage(damage);
            Destroy(gameObject);
        }
        /*
        health.Dealdamage(damage);*/
    }
}