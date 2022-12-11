using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hitX;
    private RaycastHit2D hitY;
    private Rigidbody2D _rb;
    [SerializeField] private int movementSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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


        _rb.velocity = new Vector2(moveDelta.x * movementSpeed * timeElapsed,
            moveDelta.y * movementSpeed * timeElapsed);

    }
}