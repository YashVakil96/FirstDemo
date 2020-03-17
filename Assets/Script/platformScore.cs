using UnityEngine;
using TMPro;

public class platformScore : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI platformtxt;

    public Transform Generator;
    private static int Score = -1;

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Score++;
        platformtxt.text = "Platform: " + Score.ToString();


    }
  }
