using UnityEngine;

//fa spawnare le mine/bolle in un'area random (x e z)
public class DestroyOnBulletTrigger : MonoBehaviour
{
    [SerializeField] private GameObject target; // GameObject "PADRE" da distruggere: sennò distruggi solo un pezzo de mina per es.
    [SerializeField] private GameObject spawnOnDestroy; //entità da spawnare 
    [SerializeField][Range(1, 10)] private int maxInstances = 5;
    [SerializeField] private Vector3 randomDelta = Vector3.zero; // sposta gli oggetti spawnati in modo random
    bool isdestroyed = false;
    private void OnTriggerEnter(Collider other) //ricorda OnTriggerEnter è eseguito una sola volta
    {
        if (isdestroyed) return;
        //se ci sono entità da spawnare
        if (spawnOnDestroy)
        {
            //per un num max da 1 a maxInstances
            int realInstances = Random.Range(1, maxInstances);

            //spawna (Istantiate) un numero random di entità
            for (int i = 0; i < realInstances; i++)
            {

             //infatti qui stai moltiplicando lo stesso numero casuale per tutte e tre le componenti di randomDelta (oltre a spawnare l'oggetto col metodo Ist.)
             GameObject go = Instantiate(spawnOnDestroy, transform.position + randomDelta * Random.Range(-1f, 1f),
                                         spawnOnDestroy.transform.rotation);
             
              go.transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f); // scala l'oggetto spawnato
            }
        }
        isdestroyed = true;
        Destroy(target);
    }
}