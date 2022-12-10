using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f;
    private float dirX;
    private float dirY;
    private Vector2 currSpeed = new Vector2(0, 0);
    
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        currSpeed.x = dirX * playerSpeed * Time.deltaTime;
        currSpeed.y = dirY * playerSpeed * Time.deltaTime;
        transform.position += (Vector3)currSpeed;
    }
}
