using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public playercontoller player;
    private Vector3 LastPos;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playercontoller>();
        LastPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        offset = player.transform.position.x - LastPos.x;
        transform.position = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
        LastPos = player.transform.position;
    }
}
