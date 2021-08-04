using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : Destructable
{
   // public float time;
    [SerializeField] Animator animator;
    public override void Die()
    {
        base.Die();
       animator.SetBool("IsDying", true); //<---- need to destroy rigidbody, debug later
        print("played animation");
        //GameManager.Instance.Timer.Add(() =>
       //  time);
        //GameManager.Instance.Timer.Add(time);
          Destroy(gameObject);

    }
}
