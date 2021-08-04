using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyHealth))]
public class WinCondition : MonoBehaviour

{
    private Animator animator;
    // Start is called before the first frame update
private void WinCondition_OnDeath()
    {

       //  if (animator.SetBool("IsDying", true))
       // OnDeath();
        print("We won");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
