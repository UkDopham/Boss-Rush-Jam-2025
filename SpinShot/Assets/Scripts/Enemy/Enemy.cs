using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float health = 20;
    
    public void Hurt(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }
}
