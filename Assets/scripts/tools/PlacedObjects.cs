using UnityEngine;
using UnityEngine.InputSystem;

public class PlacedObjects : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float MaxTilte, placeDistance;
    [SerializeField] private Vector2 UpDiraction, Offset;
    [SerializeField] public bool placed, Moving;
    private Rigidbody2D _r;
    private Transform _t;
    private Vector2 startPos;
    private Vector2 lastpos;

    void Start()
    {
        _r = GetComponent<Rigidbody2D>();
        _t = transform;
        startPos = transform.position;
    }

    void Update()
    {
        _t.rotation = Quaternion.Lerp(_t.rotation, Quaternion.Euler(0, 0, Mathf.Clamp(Vector2.SignedAngle(UpDiraction, _r.position - lastpos), -MaxTilte, MaxTilte)), 10f * Time.deltaTime);
        lastpos = _r.position;

        if (target && !target.gameObject.activeSelf && !Moving && _r.position != startPos)
        {
            tostartpos();
        }
    }

    void OnMouseDrag()
    {
        Moving = true;
        if (target)
        {
            if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10), target.position) < placeDistance)
            {
                _r.position = (Vector2)target.position + Offset;
                return;
            }
        }

        _r.MovePosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.value) + new Vector3(0, 0, -10));
    }

    void OnMouseUp()
    {
        Moving = false;
        if (target && target.gameObject.activeSelf)
        {
            if (_r.position != (Vector2)target.position + Offset)
            {
                tostartpos();
            }
            else
            {
                placed = true;
            }
        }
        else
        {
            tostartpos();
        }
    }

    private void tostartpos()
    {
        _r.position = startPos;
        transform.rotation = Quaternion.identity;
        placed = false;
    }

}
