using UnityEngine;

public class MoveShapes : MonoBehaviour
{
    public Vector2 speed = new Vector2(5f, 3f); 
    private Rigidbody2D body;
    private Vector2 screenBounds;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.linearVelocity = speed;

      
        Vector3 screenBottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        screenBounds = new Vector2(screenTopRight.x, screenTopRight.y);
    }

    void Update()
    {
        Vector3 pos = transform.position;

       
        if (pos.x >= screenBounds.x && body.linearVelocity.x > 0)
        {
            body.linearVelocity = new Vector2(-body.linearVelocity.x, body.linearVelocity.y);
        }
        else if (pos.x <= -screenBounds.x && body.linearVelocity.x < 0)
        {
            body.linearVelocity = new Vector2(-body.linearVelocity.x, body.linearVelocity.y);
        }

      
        if (pos.y >= screenBounds.y && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, -body.linearVelocity.y);
        }
        else if (pos.y <= -screenBounds.y && body.linearVelocity.y < 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, -body.linearVelocity.y);
        }
    }
}
