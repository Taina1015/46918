using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStats{
    Idle = 0, Walk = 1, Jump = 2, Run = 3,
}

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimation;
    public CharacterStats characterStats;

    // Start is called before the first frame update
    void Start()
    {
     playerAnimation = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
            characterStats = CharacterStats.Walk;
        }
        else{
             characterStats = CharacterStats.Idle;
        }

        if(characterStats == CharacterStats.Walk){
            playerAnimation.SetBool("Walk", true);
        }

        if(characterStats == CharacterStats.Idle){
            playerAnimation.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            playerAnimation.SetTrigger("Jump");
        }
        else{
             characterStats = CharacterStats.Idle;
        }
         if (Input.GetKey(KeyCode.LeftShift)){
           characterStats = CharacterStats.Run;
        }
        else{
            playerAnimation.SetBool("Run", false);
        }

        if(characterStats == CharacterStats.Run){
            playerAnimation.SetBool("Run", true);
        }
        if(Input.GetKeyDown(KeyCode.F)){
             playerAnimation.SetTrigger("Throw");
        }
        if (Input.GetKey(KeyCode.LeftControl)){
           playerAnimation.SetBool("Down", true);
        }
        else{
           playerAnimation.SetBool("Down", false); 
        }
    }
}
