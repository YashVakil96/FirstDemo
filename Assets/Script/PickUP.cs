using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : MonoBehaviour
{
    public int PickUpScore;
    private Score scoremanager;

    // Start is called before the first frame update
    void Start()
    {
        scoremanager = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "Player")
        {
            PickUpScore += 100;
            scoremanager.AddScore(PickUpScore);
            gameObject.SetActive(false);
        }
        
    }
}
