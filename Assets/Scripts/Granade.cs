using UnityEngine;
using UnityEngine.Events;

public class Granade : MonoBehaviour
{
    public float timer;
    public float radius;
    public LayerMask mask;
    public float TimeExplotion = 5f;
    public UnityEvent OnExplotion;
    
    void Start()
    {
        Invoke(nameof(OnExplode), timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExplode()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 5f, mask);

        foreach (var coll in colls)
        {
            //->mueran todos :D
            //->
        }
        //->siustema de particulas de explosion
        OnExplotion?.Invoke();

        Destroy(gameObject,TimeExplotion);

    }
}
