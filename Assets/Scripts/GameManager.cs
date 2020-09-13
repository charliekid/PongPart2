using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;

    [SerializeField] private ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        ball.Restart();
    }

    public void Score(Goal goal)
    {
        scoreKeeper.AddScore(goal);
        ball.Restart();
    }


}
