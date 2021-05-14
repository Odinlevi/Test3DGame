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
            anim.SetTrigger("attack");
        }
    }

}
