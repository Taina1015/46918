using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerPickUpDrop : MonoBehaviour
{
    public InputActionReference PickUp;

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private ObjectGrabbable objectGrabbable;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (objectGrabbable == null){
            float pickUpDistance = 2f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance)){
                Debug.Log(raycastHit.transform);
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) {
                    objectGrabbable.Grab(objectGrabPointTransform);
                }
            }
            } else{
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
        
    }
}
