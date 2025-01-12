using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject zone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {
        Vector3 positon = transform.position;
        positon.y = 0;
        GameObject spawnedObject = Instantiate(zone, positon, transform.rotation);

        Destroy(spawnedObject, 1f);
    }
}
