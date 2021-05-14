using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorHandler : MonoBehaviour
{
    private const float locomotionAnimationSmoothTime = .1f;
    
    private Animator anim;
    private CharacterController character;
    [SerializeField] private ThirdPersonMovement movement;
    [SerializeField] private GameObject WeaponParent;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercent = character.velocity.magnitude / movement.speed;
        anim.SetFloat("speedPercent", speedPercent);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (var weaponObject in WeaponParent.GetComponentsInChildren<MeshRenderer>())
            {
                if (weaponObject.enabled)
                {
                    switch (weaponObject.gameObject.name)
                    {
                        case "DobleSideSword":
                            anim.SetTrigger("swordAttack");
                            break;
                        case "DobleSideKnife":
                            anim.SetTrigger("daggerAttack");
                            break;
                        case "OneSideAxe":
                            anim.SetTrigger("axeAttack");
                            break;
                        default:
                            Debug.Log("There is no animation for this weapon");
                            break;
                    }
                }
                
            }
            
        }


    }

}
