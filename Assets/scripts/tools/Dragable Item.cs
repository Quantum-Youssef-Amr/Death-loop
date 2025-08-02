using UnityEngine;
using UnityEngine.InputSystem;

public class DragableItem : MonoBehaviour
{
    [SerializeField] private Vector2 upDiraction;
    [SerializeField] private bool returnToStart = false;
    private Rigidbody2D _r;
    private Vector2 _lastPos, _startPos;
    private Transform _t;
    public bool _canMove = true;
    void Start()
    {
        _r = GetComponent<Rigidbody2D>();
        _t = transform;
        _startPos = transform.position;
    }

    void OnMouseDrag()
    {
        if (!_canMove) return;
        
        _r.MovePosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10));
        if (_lastPos != _r.position)
            _t.rotation = Quaternion.Lerp(_t.rotation, Quaternion.Euler(0, 0, Vector2.SignedAngle(upDiraction, _r.position - _lastPos)), Time.deltaTime * 10f);
        _lastPos = _r.position;
    }

    void OnMouseUp()
    {
        if (returnToStart)
        {
            _r.position = _startPos;
            transform.rotation = Quaternion.identity;
        }
    }
}