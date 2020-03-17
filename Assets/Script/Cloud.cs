using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private GameObject cloud;
    public Transform CGP;

    private float distaceX;
    private float distaceY;
    // Start is called before the first frame update
    void Start()
    {
        cloud = GameObject.FindGameObjectWithTag("Cloud");

    }

    // Update is called once per frame
    void Update()
    {
        distaceX = Random.Range(2, 15);
        //distaceY = Random.Range(8, 13);

        transform.position = new Vector3(transform.position.x + distaceX, transform.position.y, transform.position.z);

        Instantiate(cloud, transform.position, transform.rotation);

        CGP.transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);   
    }
}