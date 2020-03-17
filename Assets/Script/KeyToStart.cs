using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        Debug.Log("Works");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
        }
    }
}
