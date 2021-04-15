using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerAttack : MonoBehaviour
{
    public MeleeWeaponTrail Trail;

    public float shakeDuration = 0.3f;
    public float shakeAmplitude = 1.3f;
    public float shakeFrequency = 2.0f;


    public float shakeElapsedTime = 0f;

    private Animator playerAnimation;
    private bool comboPossible=false;
    private int comboStep=0;
    void Awake()
    {
        playerAnimation = GetComponent<Animator>();
        Trail._emit = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Input.GetButton("Fire2"))
        {
            playerAnimation.SetBool("shield",true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            playerAnimation.SetBool("shield", false);
        }
    }

    public void Attack()
    {
        if (comboStep == 0)
        {
            //playerAnimation.Play("AttackA");
            playerAnimation.SetTrigger("AttackA");
            comboStep = 1;
            return;
        }
        if (comboStep != 0)
        {
            if (!comboPossible)
            {
                comboStep = 0;
            }
            if (comboPossible)
            {
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void Combo()
    {
        if (comboStep == 2)
        {
            playerAnimation.Play("AttackB");

        }

        if (comboStep == 3)
        {
            playerAnimation.Play("AttackC");

        }
    }

    public void ComboReset()
    {
        comboStep = 0;
        comboPossible = false;
    }

    public void enableTrail()
    {
        if (Trail._emit != true) 
        {
            Trail._emit = true;
        }

        if (Trail._emit == true) 
            return;
    }

    public void desableTrail()
    {
        if (Trail._emit == true)
        {
            Trail._emit = false;
        }

        if (Trail._emit == false)
            return;
    }
}
