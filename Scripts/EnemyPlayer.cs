using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EnemyHealth))]

public class EnemyPlayer : MonoBehaviour
{
  /*  [SerializeField]
    Scanner playerScanner;
    [SerializeField]
    SwatSoldier settings;
    PathFinder pathFinder;
    PlayerAnimation priorityTarget;
    List<Player> = myTargets;*/
      private EnemyHealth m_EnemyHealth;
    //public event System.Action<Player> OnTargetSelected;
    public EnemyHealth EnemyHealth
    {
        get
        {
            print("get enemy health");
            if (m_EnemyHealth == null)
                m_EnemyHealth = GetComponent<EnemyHealth>();
            return m_EnemyHealth;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        /*  pathFinder = GetComponent<PathFinder>();
          pathFinder.Agent.speed = AudioSettings.WalkSpeed;
          playerScanner.OnScanReady += Scanner_OnScanReady;
          Scanner_OnSCanReady();*/
      //EnemyHealth.OnDeath += EnemyHealth_OnDeath;// -----Investigate .OnDeath
        //EnemyPlayer.OnTargetSelected +=EnemyPlayer_OnTargetSelected;
    }
    private void EnemyHealth_OnDeath()
    {

    }
  /*  private void Scanner_OnScanReady()
    {
        if (priorityTarget != null)
            return;
        myTargets = playerScanner.ScanForTargets<Player>();
        if (myTargets.Count == 1)
            priorityTarget = myTargets[0];
        else
            SelectClosestTarget();
        if (priorityTarget != null){
        if (OnTargetSelected != null)
  OnTargetSelected(priorityTarget);
  }
    }*/
    // Update is called once per frame

 /*private void SelectClosestTarget()
    {
        float closestTarget = playerScanner.ScanRange;
        foreach (var possivleTarget in myTargets)
        {
            if (Vector3.Distance(transform.position, possivleTarget.transform.position) < closestTarget)
                priorityTarget = possibleTarget;
        }
    }*/
    void Update()
    {
        /* if(priorityTarget == null)
         * return;
         * transform.LookAt(priorityTarget.transform.transform.position);*/
    }
}
