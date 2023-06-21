using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    public  float lerpSpeed = 10f;


    private void Awake(){
        objectRigidbody = GetComponent<Rigidbody>();
    }
    
    public void Grab(Transform objectGrabPointTransform){
        this.objectGrabPointTransform = objectGrabPointTransform ;
        objectRigidbody.useGravity = false;
    }

    public void Drop() {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
    }

    private void FixedUpdate(){
        if(objectGrabPointTransform != null){
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }
}
