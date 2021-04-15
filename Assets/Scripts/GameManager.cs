using UnityEngine;

public class GameManager : MonoBehaviour
{

    CursorLockMode mode;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
