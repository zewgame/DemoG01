
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [Header("Collider Parameters")]
    [SerializeField] private float coliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [Header("Player Parameters")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Animator anim;
    private HealthPlayer plHealth;

    private EnemyPatrol enemyPatrol;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        // tấn công khi người chơi ở bên trong 
        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }
        if(enemyPatrol!=null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
       
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right*range*transform.localScale.x * coliderDistance
            , new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range, boxCollider.bounds.size.z * range)
            ,0,Vector2.left,0,playerLayer);
        if(hit.collider != null)
        {
            plHealth = hit.transform.GetComponent<HealthPlayer>();
        }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right * range * transform.localScale.x * coliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range, boxCollider.bounds.size.z * range));
    }
    private void damagePlayer()
    {
        if(PlayerInSight())
        {
            plHealth.TakeDame(damage);
        }
    }
    public int infoDame()
    {
        return damage;
    }    
}
