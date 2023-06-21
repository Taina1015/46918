using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerGrabItem : MonoBehaviour
{
    private ItemGrabbable itemGrabbable = null;
   
   private void Update(){
    float grabRange = 1.5f;
    Collider[] colliderArray = Physics.OverlapSphere(transform.position, grabRange);
    foreach (Collider collider in colliderArray){
        if(collider.gameObject.TryGetComponent<ItemGrabbable>(out itemGrabbable)){
            //itemGrabbable.ShowIcon();
            break;
        }
    }

    if (Input.GetKeyDown(KeyCode.E)){
        if (itemGrabbable != null){
            //itemGrabbable.DestroySelf();
        }
    }
   }
}
