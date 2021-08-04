using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAssaultRifle : EnemyMuzzle
{
    public override void Fire()
    {
        base.Fire();
        if (canFire)
        {
            //we fire the gun
        }
    }
}
