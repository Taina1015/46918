using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private ItemGrabbable1 itemGrabbable = null;

    // Update is called once per frame
    void Update()
    {
        float grabRange = 1.5f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, grabRange);
        foreach (Collider collider in colliderArray)
        {
            if(collider.gameObject.TryGetComponent<ItemGrabbable1>(out itemGrabbable))
            {
                break;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(itemGrabbable != null)
            {
                itemGrabbable.DestroySelf();
            }
        }
    }
}
