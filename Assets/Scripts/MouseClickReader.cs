using UnityEngine;
using UnityEngine.Events;

public class MouseClickReader : MonoBehaviour
{
    private const int LeftMouseButton = 0; 

    public event UnityAction Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
            Clicked?.Invoke();
    }
}
