using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private GameObject impact;
    private float damage = 10f;
    private float range = 100f;
    private ParticleSystem particleSystem;

    private void Awake()
    {
        this.particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        RaycastHit hit;
        this.particleSystem.Play();
        if(Physics.Raycast(this.camera.transform.position, this.camera.transform.forward, out hit, this.range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Hurt(this.damage);
            }

            GameObject impactGameObject = Instantiate(this.impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 2f);
        }
    }
}
