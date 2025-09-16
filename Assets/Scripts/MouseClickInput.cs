using UnityEngine;
using UnityEngine.Events;

public class MouseClickInput : MonoBehaviour
{
    private const int MouseCode = 0; 

    public event UnityAction Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseCode))
            Clicked?.Invoke();
    }
}
