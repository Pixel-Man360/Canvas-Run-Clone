using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    internal float MouseX{get; private set;}
    internal float MouseY{get; private set;}
    
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
    }
}
