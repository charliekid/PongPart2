using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float amplitude;
    [SerializeField] private float step;
    private float startAmplitude;

    private Rigidbody rb;

    private AudioSource audioSource;

    public AudioClip leftPaddleClip;
    public AudioClip rightPaddleClip;
    public AudioClip tennisHitClip;

    private string lastObjectHit;

    // Timer stuff for Power ups
    private float waitTime = 10.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private bool powerUpOn = false;


    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startAmplitude = amplitude;

        // Audio stuff
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    public void Restart()
    {
        amplitude = startAmplitude;
        rb.MovePosition(Vector3.zero);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * amplitude; // change to send to losing side
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            //play sound
            if(collision.gameObject.name == "PaddleLeft")
            {
                lastObjectHit = "PaddleLeft";
                if(rb.velocity.magnitude < 10)
                {
                    audioSource.PlayOneShot(leftPaddleClip);
                } 
                else
                {
                    audioSource.PlayOneShot(tennisHitClip);
                } 
            }
            else
            {
                lastObjectHit = "PaddleRight";
                if (rb.velocity.magnitude < 10)
                {
                    audioSource.PlayOneShot(rightPaddleClip);
                }
                else
                {
                    audioSource.PlayOneShot(tennisHitClip);
                }
            }
            if(collision.gameObject.name == "PowerUp")
            {
                // Give someone a power up!
                powerUpOn = true;

            }

            amplitude += step;
            float offset = Mathf.Pow((transform.position.z - collision.transform.position.z), 2);
            offset = (transform.position.z - collision.transform.position.z < 0) ? offset * -1 : offset;

            rb.velocity = (collision.gameObject.name == "PaddleLeft")
                ? new Vector3(amplitude, 0, offset)
                : new Vector3(-amplitude, 0, offset);
        }  
    }
    private void Update()
    {
        if (powerUpOn == true)
        {
            RunPowerUp();
        }
    }

    private void RunPowerUp()
    {
        // Figuring out which object we are changing
        if (lastObjectHit.Equals("PaddleLeft"))
        {
            // do something to left paddle
            //yield return new WaitForSeconds(10f);
        }
        else 
        {
            // do this for only 10 seconds
            //yield return new WaitForSeconds(10f);
        }
        /*timer += Time.delta;

        // Check to see if we are over 10 seconds 
        // apparently on Unity's documentation they substract 2 cause it was
        // etter than resetting to zero.
        if (timer > waitTime)
        {
            visualTime = timer;

            // Remove the recorded 2 seconds
            timer = timer - waitTime;
            powerUpOn = false;
        }*/
    }
}
