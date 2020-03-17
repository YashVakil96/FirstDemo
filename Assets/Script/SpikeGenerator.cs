using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public ObjectPooler SpikePool;

   public void SpawnSpike(Vector3 StartPosition)
    {
        GameObject Spike = SpikePool.GetPooledObject();
        Spike.transform.position = StartPosition;
        Spike.SetActive(true);
    }
}
