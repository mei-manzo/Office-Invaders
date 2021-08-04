using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyPlayer))]
[RequireComponent(typeof(PlayerShoot))]
public class EnemyShoot : WeaponController
{
    [SerializeField]
    float shootingSpeed;
    [SerializeField]
    float burstDurationMax;
    [SerializeField]
    float burstDurationMin;
    EnemyPlayer enemyPlayer;
    Shooter assaultRifle;
    public GameObject player;

    bool shouldFire;
    // Start is called before the first frame update
    void Start()
    {
        enemyPlayer = GetComponent<EnemyPlayer>();
        StartBurst();

      //  enemyPlayer.OnTargetSelected += EnemyPlayer_OnTargetSelected;
    }

       private void EnemyPlayer_OnTargetSelected(GameObject player) // points at player
       {
    print ("OnTargetSelected");
          ActiveWeapon.AimTarget = player.transform;
          ActiveWeapon.AimTargetOffset = Vector3.up * 1.5f; //-------Need to sub actual weapon game object for active weapon
     // StartBurst();
       }
    // Update is called once per frame
    void StartBurst()
    {
        if (!enemyPlayer.EnemyHealth.IsAlive)
            return;
     //   CheckReload();
        shouldFire = true;
        GameManager.Instance.Timer.Add(EndBurst, Random.Range(burstDurationMin, burstDurationMax));
    }
    void EndBurst()
    {
        shouldFire = false;
        if (!enemyPlayer.EnemyHealth.IsAlive)
            return;
       // CheckReload();
        GameManager.Instance.Timer.Add(StartBurst, shootingSpeed);
    }
  /*void CheckReload() { if (ActiveWeapon.Reloader.RoundsRemainingInCLip == 0)
            ActiveWeapon.Reload;
    }*/
        
        void Update()
    {
        if (!shouldFire || !CanFire || !enemyPlayer.EnemyHealth.IsAlive)
            return;
        ActiveWeapon.Fire();  //------------swap out Active weapon
    }
}
