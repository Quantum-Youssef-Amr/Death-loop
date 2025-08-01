using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] private UnityEvent Clicked;


    void OnMouseDown()
    {
        Clicked?.Invoke();
    }
}
