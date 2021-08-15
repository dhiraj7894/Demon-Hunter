using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttackController : MonoBehaviour
{

    public CapsuleCollider hitCollider;
    void Start()
    {
        hitCollider.enabled = false;
    }

    public void enableCollider()
    {
        if (hitCollider.enabled == false)
            hitCollider.enabled = true;

        if (hitCollider.enabled == true)
            return;
    }
    public void desableCollider()
    {
        if (hitCollider.enabled == true)
            hitCollider.enabled = false;

        if (hitCollider.enabled == false)
            return;
    }

}
