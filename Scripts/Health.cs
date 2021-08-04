using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable
{
    public override void Die()
    {
        base.Die();
     //   print("We died");
       Destroy(gameObject);
 
    }

    public override void TakeDamage(float amount)
    {
      
        base.TakeDamage(amount);
      //  print("Remaining:" + HitPointsRemaining);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
