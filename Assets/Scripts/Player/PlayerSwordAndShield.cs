using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAndShield : MonoBehaviour
{

    public GameObject Sword;
    public CapsuleCollider SwordCollider;
    public GameObject Shield;
    private void Start()
    {
        SwordCollider.enabled = false;
        Shield.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }

    public void colliderActive()
    {
        if(SwordCollider.enabled == false)
            SwordCollider.enabled = true;
/*
        if (Sword.transform.GetChild(0).gameObject.GetComponent<Collider>().enabled == true)
            return;*/
    }
    public void colliderInactive()
    {
        if (SwordCollider.enabled == true)
            SwordCollider.enabled = false;
/*
        if (Sword.transform.GetChild(0).gameObject.GetComponent<Collider>().enabled == false)
            return;*/
    }

    public void shieldActive()
    {
        Shield.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
    }

    public void shieldDeactive()
    {
        Shield.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
    }
}
