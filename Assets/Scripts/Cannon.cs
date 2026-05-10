using Sirenix.OdinInspector;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float range = 10f;
    public float rotationSpeed = 5f;

    
    public Transform firePoint;
    public Transform head;
    public float fireRate = 1f;
    private float fireTimer;
    private Transform target;
    public LineRenderer laserPrefab;
    [FoldoutGroup("FX")] public float lineDuration = 0.05f;
    [FoldoutGroup("FX")]
    public ParticleSystem impactParticlesPrefab;
  
    void Update()
    {
        FindTarget();

        if (target == null) return;

        Aim();
        Shoot();
    }

    void FindTarget() // encuentra al enemigo más cercano dentro del rango
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (enemy == null)
        {
            target = null;
            return;
        }

        float dist = Vector3.Distance(transform.position, enemy.transform.position);

        if (dist <= range)
            target = enemy.transform;
        else
            target = null;
    }

    void Aim() // gira a torre para mirar 
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir);
        head.rotation = Quaternion.Slerp(head.rotation,rot,rotationSpeed * Time.deltaTime);

    }

    void Shoot() // dispara projétil
    {

        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;

            LineRenderer line = Instantiate(laserPrefab);

            line.positionCount = 2;

            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, target.position + Vector3.up);

            ParticleSystem impact = Instantiate(impactParticlesPrefab,target.position,Quaternion.identity);

            Destroy(impact.gameObject, 2f);

            Destroy(line.gameObject, lineDuration);

            Destroy(target.gameObject);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
