using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform groundDetection;

    private bool left = true;
    private Score scorepoint;
    private bool isMoving=false;

    private void Start()
    {
        scorepoint = FindObjectOfType<Score>();
        if (scorepoint.ScorePoint > 10000)
        {
            speed =Random.Range(3, 6);
            isMoving = true;
        }
        if (scorepoint.ScorePoint > 20000)
        {
            speed = Random.Range(6,11);
            isMoving = true;
        }

    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if(speed>0)
        {
            IsMoving();
        }
    }

    void IsMoving()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo == false)
        {
            if (left == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                left= false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                left = true;
            }
        }
    }

}