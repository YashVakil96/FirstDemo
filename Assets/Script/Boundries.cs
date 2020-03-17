using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
    private float pw;
    private float ph;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        pw = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        Debug.Log("PW :" + pw);
        ph = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        Debug.Log("Ph :" + ph);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + pw, screenBounds.x * -1 - pw);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + ph, screenBounds.y * -1 - ph);
        transform.position = viewPos;
    }
}
