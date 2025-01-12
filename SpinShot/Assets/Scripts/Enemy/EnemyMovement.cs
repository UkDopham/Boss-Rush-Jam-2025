using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float speed = 3.0f;
    private float stoppingDistance = 2.0f;
    private EnemyAttack enemyAttack;

    private void Awake()
    {
        this.enemyAttack = GetComponent<EnemyAttack>();
    }
    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned.");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
        }
        else
        {
            this.enemyAttack.Attack();
        }
    }
}
