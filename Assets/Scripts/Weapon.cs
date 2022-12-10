using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected Camera sceneCamera;
    [SerializeField] protected float attackCooldown;
    protected Animator _anim;
    protected float _previousAttack;
    protected bool _isAttacking = false;
    protected float _attackStartTime;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckAttack();
        Vector2 playerPosition = sceneCamera.WorldToViewportPoint(transform.parent.position);
        Vector2 mousePosition = sceneCamera.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(playerPosition, mousePosition);
        angle = -(180 - angle);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.position = transform.parent.position;
        transform.position += GetMovement(angle) * 0.5f;
        if (_isAttacking)
        {
            Attack();
        }
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private Vector3 GetMovement(float angle)
    {
        float xMovement = Mathf.Cos(Mathf.Deg2Rad * angle);
        float yMovement = Mathf.Sin(Mathf.Deg2Rad * angle);
        return new Vector3(xMovement, yMovement, 0);
    }

    protected virtual void Attack()
    {
        Debug.Log("Not overrided attack");
    }

    protected virtual void CheckAttack()
    {
        Debug.Log("Not overrided CheckAttack");
    }

}
