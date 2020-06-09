using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    //ARROW SPAWNER AND TIMER

    float spawnDelay;

    [SerializeField]
    GameObject[] arrow;

    float nextTimeToSpawn = 0f;

    private void Update()
    {
        spawnDelayDecrease();

        if (nextTimeToSpawn <= Time.time) //Time.time is the number of seconds elapsed since the start of the game
        {
            SpawnArrow();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    //the more levels we go through, the faster the sharks become
    void spawnDelayDecrease()
    {
        //spawnDelay = Mathf.Pow(1.4f, -(7-1) + 3.7f); // exponential
        spawnDelay = 2f / ((float)Courage.courage+1); // division
    }

    void SpawnArrow()
    {
        int randomIndex = Random.Range(0, arrow.Length);
        Transform spawnPoint = arrow[randomIndex].transform;

        switch (randomIndex)
        {
            case 0:
                Instantiate(arrow[0], spawnPoint.position, spawnPoint.rotation);
                break;
            case 1:
                Instantiate(arrow[1], spawnPoint.position, spawnPoint.rotation);
                break;
            case 2:
                Instantiate(arrow[2], spawnPoint.position, spawnPoint.rotation);
                break;
            case 3:
                Instantiate(arrow[3], spawnPoint.position, spawnPoint.rotation);
                break;
            default:
                Debug.Log("No arrow");
                break;
        }
    }
}
