using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blendtree : MonoBehaviour
{
    private int H1 = Animator.StringToHash("H1");
    private int V1 = Animator.StringToHash("V1");
    private float speedMax; 
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
           speedMax = 2; 
        }
        else{
            speedMax = 1; 
        }
        anim.SetFloat(H1, Input.GetAxis("Vertical")*speedMax);
        anim.SetFloat(V1, Input.GetAxis("Horizontal")*speedMax);
    }
}
