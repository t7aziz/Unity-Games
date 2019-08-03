using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text score;
    public Text highScore;
    public float curScore = 0f;

    //Start is called before the first frame update
    void Start()
    {
        highScore.text = highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        if (!GameObject.Find("Canvas").GetComponent<PauseMenu>().GameIsPaused && !GameObject.Find("Canvas").GetComponent<PauseMenu>().MainMenuUp)
        {
            curScore += 0.001f;
        }
        
        SetScoreText((int) curScore);

        if (PlayerPrefs.GetInt("HighScore") <= curScore)
        {
            SetHighScore((int) curScore);
        }
    }
    public void SetScoreText(int num)
    {
        score.text = num.ToString();
    }
    public void SetHighScore(int num)
    {
        PlayerPrefs.SetInt("HighScore", num);
    }
    public void AddToScore(int num)
    {
        curScore += num;
    }
}
