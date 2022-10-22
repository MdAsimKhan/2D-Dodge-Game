using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectorScript : MonoBehaviour
{
    public Text scoreText;
    private static int score;

    public static int Score
    {
        get { return score; }
        set { score = value; }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("demon"))
        {
            ScoreUp();
            Destroy(target.gameObject);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
