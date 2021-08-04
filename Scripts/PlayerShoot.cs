using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerControl))]
public class PlayerShoot : WeaponController
{
    bool IsPlayerAlive;
    PlayerHealth playerHealth;
    void Start()
    {
        IsPlayerAlive = true;
        GetComponent<PlayerControl>().PlayerHealth.OnDeath += PlayerHealth_OnDeath;
    }
//    [SerializeField] Shooter assaultRifle;
private void PlayerHealth_OnDeath()
    {
        IsPlayerAlive = false;
    }

    void Update()
    {
        // if (!CanFire)
        //    return;
        /* if (GameManager.Instance.InputController.MouseWheelDown)
             SwitchWeapon(1);
         if (GameManager.Instance.InputController.MouseWheelUp)
             SwitchWeapon(-1);
         if (GameManager.Instance.LocalPlayer.PlayerState.MoveState == PlayerState.EMoveState.SPRINTING)
             return;*/
        if (!IsPlayerAlive)
            return;
        if (!CanFire)
            return;
        if (GameManager.Instance.InputController.Fire1)
        {
            ActiveWeapon.Fire();
           //AssaultRifle.Fire();
        }
    }
}
