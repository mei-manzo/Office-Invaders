using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMuzzle : MonoBehaviour
{
    public GameObject projectilePrefab;
  public float bulletSpeed;
    private GameObject player;
    float nextFireAllowed;
    public bool canFire;
    [SerializeField] float rateOfFire;
    Transform enemyMuzzle;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        enemyMuzzle = transform.Find("EnemyMuzzle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        projectilePrefab.transform.Translate(lookDirection * bulletSpeed * Time.deltaTime);
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
    public virtual void Fire()
    {

        canFire = false;
        if (Time.time < nextFireAllowed)
            return;
        nextFireAllowed = Time.time + rateOfFire;

        //instantiate the projectile;

        Instantiate(projectilePrefab, enemyMuzzle.position, enemyMuzzle.rotation);

        canFire = true;
    }
}
