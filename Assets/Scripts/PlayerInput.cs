// using UnityEngine;
// using UnityEngine.AI;

// public class PlayerInput : MonoBehaviour
// {
//     [SerializeField]
//     private Camera Camera;
//     [SerializeField]
//     private LayerMask FloorLayers;
//     [SerializeField]
//     private NavMeshAgent Agent;

//     private void Update()
//     {
//         if (Input.GetKeyUp(KeyCode.Mouse1))
//         {
//             if (Physics.Raycast(Camera.ScreenPointToRay(Input.mousePosition), out RaycastHit Hit, float.MaxValue, FloorLayers))
//             {
//                 Agent.SetDestination(Hit.point);
//             }
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PlayerInput : MonoBehaviour
{
   
   public Transform targetObject;
   public Vector3 cameraOffset;
   public float smoothFactor = 0.5f;
   public bool lookAtTarget = false;



  void Start()
   {
          cameraOffset = transform.position - targetObject.transform.position;
   }



   private void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset ;
        transform.position =Vector3.Slerp(transform.position, newPosition, smoothFactor);
        
        if(lookAtTarget)
        {
        transform.LookAt(targetObject);
        }        
    }
}