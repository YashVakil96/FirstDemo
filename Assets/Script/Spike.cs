using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        this.enabled = true;
        if (this.enabled)
        {
            Vector3 move = new Vector3(0f, 1f, 0f);
            transform.Translate(move);
            this.enabled = false;
        }   
        
    }
  
}
