using UnityEngine;
using UnityEngine.InputSystem;

public class DragableItem : MonoBehaviour {
    [SerializeField] private Vector2 upDiraction;
    private Rigidbody2D _r;
    private Vector2 _lastPos;
    private Transform _t;
    void Start()
    {
        _r = GetComponent<Rigidbody2D>();
        _t = transform;
    }

    void OnMouseDrag()
    {
        _r.MovePosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10));
        if(_lastPos != _r.position)
            _t.rotation = Quaternion.Lerp(_t.rotation, Quaternion.Euler(0, 0, Vector2.SignedAngle(upDiraction, _r.position - _lastPos)), Time.deltaTime * 10f);
        _lastPos = _r.position;
    }
}