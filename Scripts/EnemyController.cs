
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField] int countdown;
    public float speed;
    public Rigidbody enemyRb;
   // [SerializeField] float rateOfFire;
    private GameObject player;
  //  public GameObject projectilePrefab;
  //  float nextFireAllowed;
  //  public bool canFire;
  //  Transform enemyMuzzle;
    [SerializeField] Transform cannon;
    [SerializeField] AudioController footSteps;
    [SerializeField] float minimumMoveThreshold;
    Vector3 previousPosition;
    //  public Image Bar;

    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    //    enemyMuzzle = transform.Find("EnemyMuzzle");
       // transform.SetParent(cannon);
        //playerInput = GameManager.Instance.InputController;

    }
    IEnumerator ExampleCoroutine()
    {
        //Set enemy direction towards player goal and move there
        yield return new WaitForSeconds(countdown);
    }

    void Update()
    {
   
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

       
        //overallSpeed
        Vector3 horizontalVelocity = enemyRb.velocity;
        horizontalVelocity = new Vector3(enemyRb.velocity.x, 0, enemyRb.velocity.z);

        // turns enemy to look at player
        transform.LookAt(player.transform);

        //launches projectile toward player
      //  cannonPosition = cannon.position;
       /* projectilePrefab.transform.Translate(lookDirection * speed * Time.deltaTime);
        Instantiate(projectilePrefab, transform.position, transform.rotation);*/
        // if (playerInput.IsWalking)
        //    moveSpeed = walkSpeed;
        if (Vector3.Distance(transform.position, previousPosition) > minimumMoveThreshold)
            footSteps.Play();
        previousPosition = transform.position;
    }

   /* public virtual void Fire()
    {

        canFire = false;
        if (Time.time < nextFireAllowed)
            return;
        nextFireAllowed = Time.time + rateOfFire;

        //instantiate the projectile;

        Instantiate(projectilePrefab, enemyMuzzle.position, enemyMuzzle.rotation);

        canFire = true;
    }*/
}

