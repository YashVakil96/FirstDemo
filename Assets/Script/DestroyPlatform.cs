using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private GameObject platformDestructionPoint;

    private void Start()
    {
        platformDestructionPoint = GameObject.Find("platformDestructionPoint");
    }

    private void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
