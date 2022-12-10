using UnityEngine;

public class MeleeWeapon : Weapon
{
    protected override void Attack()
    {
        
    }

    protected override void CheckAttack()
    {
        if (Input.GetMouseButton(0) && Time.time - _previousAttack > attackCooldown)
        {
            _previousAttack = Time.time;
            _anim.SetTrigger("attack");
            _isAttacking = true;
            _attackStartTime = Time.time;
        }
    }
}
