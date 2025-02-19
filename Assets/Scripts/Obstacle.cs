using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float leftBoundary = -10;

    // Update is called once per frame
    void Update()
    {
        MoverObstacle();    
    }
    
    private void MoverObstacle()
    {
        transform.position += Vector3.left * (GameManager.instance.GetGameSpeed() * Time.deltaTime);
        if(transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
