using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public  ObjectPooler CoinPool;
    public float distanceBetweenCoins;

   public void SpawnCoins(Vector3 startPosition)
    {
            GameObject coin = CoinPool.GetPooledObject();
            //startPosition = new Vector3(startPosition.x, startPosition.y, startPosition.z);
            //Debug.Log(startPosition);
            coin.transform.position = startPosition;
            coin.SetActive(true);
    }
}
