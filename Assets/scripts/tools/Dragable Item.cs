using UnityEngine;
using UnityEngine.InputSystem;

public class DragableItem : MonoBehaviour {
    private Rigidbody2D _r;

    void Start() {
        _r = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag() {
        if ((Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10) - transform.position).magnitude > 0.5f) {
            _r.AddForce((Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10) - transform.position) * 10, ForceMode2D.Force);
            _r.transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, _r.linearVelocity));
        }
    }
}