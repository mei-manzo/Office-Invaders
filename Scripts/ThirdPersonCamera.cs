using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour { 
    [SerializeField]Vector3 cameraOffset;
    [SerializeField]float damping;
   // public GameObject mainCamera;
    Transform cameraLookTarget;
    PlayerControl localPlayer;
    // Start is called before the first frame update
    void Awake()
    {
      //  if (localPlayer == null)
        //    return;
        //   mainCamera = GameObject.FindGameObjectWithTag("Main camera");
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoined;
        
    }
    void HandleOnLocalPlayerJoined (PlayerControl player)
    {
        localPlayer = player;
        cameraLookTarget = localPlayer.transform.Find("cameraLookTarget");
   

        if (cameraLookTarget == null)
            cameraLookTarget = localPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = cameraLookTarget.position + localPlayer.transform.forward * cameraOffset.z +
            localPlayer.transform.up * cameraOffset.y +
            localPlayer.transform.right * cameraOffset.x;
        Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

     //   Vector3 collisionTargetPoint = cameraLookTarget.position + localPlayer.transform.up;
        //   Debug.DrawLine(targetPosition, collisionCheckEnd, Color.blue);
        /*RaycastHit hit;
        if (Physics.Linecast(collisionTargetPoint, targetPosition, out hit))
        {
            Vector3 hitPoint = new Vector3(hit.point.x + hit.normal.x * .2f, hit.point.y, hit.point.z + hit.normal.z * .2f);
            targetPosition = new Vector3(hit.point.x, targetPosition.y, hit.point.z);
        }*/
     //   Vector3 collisionDestination = cameraLookTarget.position + localPlayer.transform.up - localPlayer.transform.forward*.5f;
     //  HandleCameraCollision(collisionDestination, ref targetPosition);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    
        }
  /*  private void HandleCameraCollision(Vector3 toTarget, ref Vector3 fromTarget)
    {
        RaycastHit hit;
        if (Physics.Linecast(toTarget, fromTarget, out hit))
        {
            Vector3 hitPoint = new Vector3(hit.point.x + hit.normal.x * .2f, hit.point.y, hit.point.z + hit.normal.z * .2f);
            fromTarget = new Vector3(hit.point.x, fromTarget.y, hit.point.z);
        }

    }*/
}
