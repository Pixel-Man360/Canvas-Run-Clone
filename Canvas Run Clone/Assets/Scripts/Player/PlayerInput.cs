using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    internal float MouseX{get; private set;}
    internal float MouseY{get; private set;}
    
    void Update()
    {
        MouseX = Input.GetAxisRaw("Mouse X");
        MouseY = Input.GetAxisRaw("Mouse Y");
    }
}
