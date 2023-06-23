using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D OtherCollider)
    {
        Attacker attacker = OtherCollider.GetComponent<Attacker>();
        if (attacker)
        {
            // Do animation
        }
    }
    
}
