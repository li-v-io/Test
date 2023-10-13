using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    public GameObject LeftArm;
    public GameObject RightArm;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public AudioClip AttackAudio;
    public bool IsAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 - Left
        {
            if (CanAttack)
            {
                LeftAttack();
            }
        }
        if(Input.GetMouseButtonDown(1)) // 1 - Right
        {
            if (CanAttack)
            {
                RightAttack();
            }
        }
    }

    public void LeftAttack()
    {
        IsAttacking = true;
        CanAttack = false;

        Animator anim = LeftArm.GetComponent<Animator>();
        anim.SetTrigger("Attack_Left");

        AudioSource ac = GetComponent<AudioSource>();

        ac.PlayOneShot(AttackAudio);
        StartCoroutine(ResetAttackCooldown());
    }

    public void RightAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = RightArm.GetComponent<Animator>();
        anim.SetTrigger("Attack_Right");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(AttackAudio);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }
}