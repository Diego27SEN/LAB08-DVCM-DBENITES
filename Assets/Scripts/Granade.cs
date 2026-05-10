using UnityEngine;
using UnityEngine.Events;

public class Granade : MonoBehaviour
{
    public float radius;
    public LayerMask enemyMask;
    public float TimeExplotion = 5f;
    public UnityEvent OnExplotion;
    public GameObject explosionPrefab;

    void Start()
    {
        Invoke(nameof(OnExplode), TimeExplotion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExplode()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position,radius,enemyMask);

        foreach (var coll in colls)
        {
            //->mueran todos :D
            //->
            Destroy(coll.transform.root.gameObject);
        }
        //->siustema de particulas de explosion
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);


        Destroy(gameObject);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
