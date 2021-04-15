using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{

    public GameObject Sword;

    public void colliderActive()
    {
        Sword.transform.GetChild(0).gameObject.GetComponent<Collider>().enabled = true;
    }
    public void colliderInactive()
    {
        Sword.transform.GetChild(0).gameObject.GetComponent<Collider>().enabled = false;
    }
}
