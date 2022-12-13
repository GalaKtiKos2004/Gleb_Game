using UnityEngine;

public class MeleeWeapon : Weapon
{
    private Vector3 attackVelocity;
    private Vector3 weaponMovement;
    private Vector3 attackRestoreVelocity;
    private Vector3 directionMemory;
    private float angleMemory;
    
    protected override void AttackAnimate()
    {
        if (Time.time - _attackStartTime < .1f)
        {
            weaponMovement += attackVelocity * Time.deltaTime;
        }
        else if (Time.time - _attackStartTime < .3f)
        {
            weaponMovement -= attackRestoreVelocity * Time.deltaTime;
        }
        else
        {
            _isAttacking = false;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angleMemory));
        transform.position = transform.parent.position;
        transform.position += directionMemory;
        transform.position += weaponMovement;
    }

    protected override void CheckAttack()
    {
        if (Input.GetMouseButton(0) && Time.time - _previousAttack > attackCooldown)
        {
            _previousAttack = Time.time;
            _anim.SetTrigger("attack");
            _isAttacking = true;
            _attackStartTime = Time.time; 
            directionMemory = transform.position - transform.parent.position;
            attackVelocity = GetMovement(angle) * 10f;
            attackRestoreVelocity = attackVelocity * .5f;
            weaponMovement = Vector2.zero;
            angleMemory = angle;
        }
    }
}
