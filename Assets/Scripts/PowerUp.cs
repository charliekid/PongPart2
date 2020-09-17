using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //private Text extraText; 
    
    private IEnumerator OnTriggerEnter(Collider other)
    {
        // We are use this to figure out which power up will be used 
        int randomNumber = Random.Range(1, 10);

        GameObject paddleLeft = GameObject.Find("PaddleLeft");
        GameObject paddleRight = GameObject.Find("PaddleRight");
        
        if (randomNumber % 2 == 0)
        {
            // This power up shrinks your paddle
            if (Ball.lastObjectHit.Equals("PaddleLeft"))
            {
                // Shrink the right paddle for 5 seconds
                paddleRight.transform.localScale += new Vector3(-0.50f, -0.50f, -2.5f);
                yield return new WaitForSeconds(5);
                paddleRight.transform.localScale += new Vector3(0.50f, 0.50f, 2.5f);
                paddleRight.transform.position = new Vector3(10, 1, 0);
            }
            else
            {
                // Shrink the right paddle for 5 seconds
                paddleLeft.transform.localScale += new Vector3(-0.50f, -0.50f, -2.5f);
                yield return new WaitForSeconds(5);
                paddleLeft.transform.localScale += new Vector3(0.50f, 0.50f, 2.5f);
                paddleLeft.transform.position = new Vector3(-10, 1, 0);
            }
        }
        // This power up allows them to get an extra point
        else
        {
            Debug.Log(Ball.lastObjectHit + " GETS AN EXTRA POINT!");
            if (Ball.lastObjectHit.Equals("PaddleLeft"))
            {
                ScoreKeeper.leftScore++;
            }
            else
            {
                ScoreKeeper.rightScore++;
            }
        }
    }
}
