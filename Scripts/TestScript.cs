using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float speed;
  //  public Rigidbody enemyRb;
    public GameObject player;
    public GameObject projectilePrefab;
    void Awake()
    {
        
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
  //  enemyRb.AddForce(lookDirection* speed);
        //overallSpeed
      //  Vector3 horizontalVelocity = enemyRb.velocity;
 //   horizontalVelocity = new Vector3(enemyRb.velocity.x, 0, enemyRb.velocity.z);
    // The overall speed
    transform.LookAt(player.transform);
       // float overallSpeed = enemyRb.velocity.magnitude;
    //   if ("IsWalking" = true)
    /*   projectilePrefab.transform.LookAt(player.transform);*/
    projectilePrefab.transform.Translate(lookDirection* speed * Time.deltaTime);
    Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    //   enemyProj.AddForce(lookDirection * speed);
}
}