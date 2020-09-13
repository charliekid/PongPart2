using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Transform leftPaddle;
    public Transform rightPaddle;
    
    [SerializeField] private float amplitude = 5;

    private float velocityLeftPaddle = 0;
    private float velocityRightPaddle = 0;

    // Update is called once per frame
    void Update()
    {
        velocityLeftPaddle = Input.GetAxis("LeftPaddle");
        velocityRightPaddle = Input.GetAxis("RightPaddle");

    }

    void FixedUpdate()
    {
        MovePaddle(new Vector3(0, 0, velocityLeftPaddle), leftPaddle);
        MovePaddle(new Vector3(0, 0, velocityRightPaddle), rightPaddle);
    }

    void MovePaddle(Vector3 direction, Transform paddle)
    {
        paddle.Translate(direction * amplitude);
    }
}
