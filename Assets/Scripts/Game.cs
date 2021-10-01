using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Ball ballPrefab;

    public Transform ballSpawnPoint;
    public float force = 100f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        Ball ball = Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
        ball.rigidBody.AddForce(ballSpawnPoint.forward * force);
    }
}
