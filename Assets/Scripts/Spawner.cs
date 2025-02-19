using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform highPos;
    [SerializeField] private Transform lowPos;
    private float timer = 0;
    [SerializeField] private float spawnInterval = 2f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0;
        }
    }
    
    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        if(randomIndex == 0 || randomIndex == 1)
        {
           GameObject obstacle = Instantiate(obstacles[randomIndex], lowPos.position, Quaternion.identity);
        }
        else
        {
            GameObject obstacle = Instantiate(obstacles[randomIndex], highPos.position, Quaternion.identity);
        }
    }  
}
