using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public GameObject player;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;


    public int ScorePoint;
    public int HighScore;

    private int PointsPerSecond = 1;
    private bool Isrunning;
    private playercontoller playercontoller;

    private void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") != 0)
        {
            HighScore = PlayerPrefs.GetInt("HighScore");
        }
        Isrunning = false;
        playercontoller = player.GetComponent<playercontoller>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (playercontoller.speed > 0)
            {
                if (player.transform.position.x > 0)
                {
                    Isrunning = true;
                }
            }
            else
            {
                Isrunning = false;

            }
            //Debug.Log(1);
            if (Isrunning)
            {
                ScorePoint += PointsPerSecond;
                ScoreText.text = "Score : " + ScorePoint.ToString("0");
                if (ScorePoint > HighScore)
                {
                    HighScore = ScorePoint;
                    PlayerPrefs.SetInt("HighScore", HighScore);
                }
            }

            HighScoreText.text = "High Score : " + HighScore.ToString("0");
        }
        
    }

    public void AddScore(int addPoints)
    {
        ScorePoint += addPoints;
        //Debug.Log("AddScore: "+ScorePoint);
    }
}
