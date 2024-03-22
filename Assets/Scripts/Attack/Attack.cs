using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyLayer;

    public void StartAction()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.TryGetComponent(out Health healthSystem))
                healthSystem.TakeDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawSphere(_attackPoint.position, _attackRange);
    }
}