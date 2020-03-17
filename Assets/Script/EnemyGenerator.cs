using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public ObjectPooler[] EnemyPool;

    private void Start()
    {
        
    }

    public void SpawnEnemy(Vector3 startPosition,int no)
    {
        GameObject enemy= EnemyPool[no].GetPooledObject();
        enemy.transform.position = startPosition;
        enemy.transform.localScale = new Vector3(6,6, 0);
        enemy.SetActive(true);
    }
}
