using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text leftTextScore;
    [SerializeField] private Text rightTextScore;

    [SerializeField] private Goal leftGoal;
    [SerializeField] private Goal rightGoal;

    [SerializeField] private GameManager gameManager;


    public static int leftScore = 0;

    public static int rightScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        RefreshScore();
    }

    private void RefreshScore()
    {
        //some function to update the Text string
        leftTextScore.text = leftScore + "";
        Debug.Log("Left score is " + leftScore); 
        rightTextScore.text = rightScore + "";
        Debug.Log("Right score is " + rightScore);

    }
    public void AddScore(Goal scoringSide)
    {
        if (scoringSide == leftGoal)
        {
            rightScore += 1;
            rightTextScore.color = NewColor();
        }

        else
        {
            leftScore += 1;
            leftTextScore.color = NewColor();
        }
        RefreshScore();
    }
    /**
    * Returns the color when the object hits something
    * @return color - the color object
    */
    private Color NewColor()
    {
        // uses random values for RGB
        Color color = new Color(UnityEngine.Random.value,
                                UnityEngine.Random.value,
                                UnityEngine.Random.value);
        return color;
    }
}
