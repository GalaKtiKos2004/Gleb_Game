using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hitX;
    private RaycastHit2D hitY;
    [SerializeField] private int movementSpeed;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float timeElapsed = Time.fixedDeltaTime;

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }



        float movementY = movementSpeed * moveDelta.y * timeElapsed;
        transform.Translate(0, movementY, 0);
        hitY = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * timeElapsed * movementSpeed), LayerMask.GetMask("Entities", "Blocks"));
        if (hitY.collider is not null)
        {
            transform.Translate(0, -movementY, 0); 
        }
            
            
        float movementX = movementSpeed * moveDelta.x * timeElapsed;
        transform.Translate(movementX, 0, 0);
        hitX = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * timeElapsed * movementSpeed), LayerMask.GetMask("Entities", "Blocks")); 
        if (hitX.collider is not null)
        {
            transform.Translate(-movementX, 0, 0);
        }

    }
}