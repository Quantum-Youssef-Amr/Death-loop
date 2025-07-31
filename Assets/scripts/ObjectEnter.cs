using UnityEngine;
using System.Collections;

using UnityEngine.InputSystem;
public class ObjectEnter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool isMoving = false;
    public float moveSpeed = 2f;
    [SerializeField] Transform fromObject;
    [SerializeField] Transform toObject;
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (!isMoving)
                {
                    if (Vector3.Distance(transform.position, fromObject.position) < 0.01f)
                        StartCoroutine(MoveToPosition(toObject));
                    else if (Vector3.Distance(transform.position, toObject.position) < 0.01f)
                        StartCoroutine(MoveToPosition(fromObject));
                }
            }
            Debug.Log("MOUSE CLICK");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }
   
    private void OnMouseDown()
    {
       
     
    }
    private IEnumerator MoveToPosition(Transform pos)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, pos.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, pos.position, moveSpeed * Time.deltaTime);
            yield return null; 
        }

        transform.position = pos.position; 
        isMoving = false;
    }

}
