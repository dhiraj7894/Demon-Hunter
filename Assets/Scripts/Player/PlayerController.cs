using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    // Start is called before the first frame update
    void Awake()
    {
        playerAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && playerAnim.GetFloat("vertical") <= 0.1f)
        {
            playerAnim.SetTrigger("jump");
        }
        if (Input.GetButtonDown("Jump") && playerAnim.GetFloat("vertical")>=0.1f)
        {
            playerAnim.SetTrigger("vault");
        }
    }
}
