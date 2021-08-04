using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAssaultRifle : MonoBehaviour
{
    [SerializeField] float rateOfFire;
    [SerializeField] Projectile projectile;
    [SerializeField] Transform hand;
    // [SerializeField] AudioController audioReload;
    [SerializeField] AudioController audioFire;

    //public WeaponReloader Reloader;
    //private ParticleSystem muzzleFireParticleSystem;
    float nextFireAllowed;
    public bool canFire;
    Transform muzzle;
    // Start is called before the first frame update
    public void Equip()
    {
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    void Awake()
    {
        muzzle = transform.Find("Muzzle");
        //Reloader = GetComponent<WeaponReloader>();
        //    muzzleFireParticleSystem = muzzle.GetComponent<ParticleSystem>();
        // transform.SetParent(hand);
    }
    /* public void Reload()
     {
         if (Reloader == null)
             return;
         Reloader.Reload();
         audioReload.Play();
     }
     void FireEffect()
     {
         if (muzzleFireParticleSystem == null)
             return;
         muzzleFireParticleSystem.Play();
     }*/
    public virtual void Fire()
    {

        canFire = false;
        if (Time.time < nextFireAllowed)
            return;
        /*if(Reloader != null)
        {
            if (Reloader.IsReloading)
                return;
            if (Reloader.RoundsRemainingInClip == 0)
                return;
            Reloader.TakeFromClip(1);
        }*/
        nextFireAllowed = Time.time + rateOfFire;
        //muzzle.LookAt(AimTarget.position + AimTargetOffset);// ------Added in for enemy, may have to swap out for FindTag("Player")
        //instantiate the projectile;
        Instantiate(projectile, muzzle.position, muzzle.rotation);
        audioFire.Play();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
