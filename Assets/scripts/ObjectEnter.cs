using UnityEngine;
using UnityEngine.InputSystem;
public class ObjectEnter : MonoBehaviour
{
    [SerializeField] private float distanceToClick = 2f, tilt = 30f;
    [SerializeField] private Transform TargetPos;
    private Rigidbody2D _r;
    private Transform _t;
    private Vector2 _lastpos;

    void Start()
    {
        _r = GetComponent<Rigidbody2D>();                   // object rigidbody
        _t = transform;                                     // transform cache
        _lastpos = transform.position;                      // setting the _last pos vector to start pos
    }

    void Update()
    {
        // lerping the rotation
        _t.rotation = Quaternion.Lerp(_t.rotation, Quaternion.Euler(0, 0, Mathf.Clamp(Vector2.SignedAngle(Vector2.up, _r.position - _lastpos), -tilt, tilt)), Time.deltaTime * 10f);
        // setting the last pos as the current
        _lastpos = _r.position;
    }

    void OnMouseDrag()
    {
        // if the distance is less than the click distance go to the targer pos and return
        if (Vector2.Distance(TargetPos.position, Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10)) < distanceToClick)
        {
            transform.position = TargetPos.position;
            return;
        }
        // if bigger move the object to the mouse pos
        _r.MovePosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10));
    }
}
