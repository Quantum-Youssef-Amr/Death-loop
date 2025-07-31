using UnityEngine;
using UnityEngine.InputSystem;

public class syringeopener : MonoBehaviour
{
    private Rigidbody2D _r;
    void Start()
    {
        _r = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag()
    {
        _r.AddForce(((Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.value) - _r.position) * 100, ForceMode2D.Force);
    }
}
