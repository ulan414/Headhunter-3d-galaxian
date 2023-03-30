using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    public WaveCount waveCount;
    public EnemyKilled EnemyKilled;
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;
    private Vector3 spawnPoint = new Vector3(0, 5.39f, 151.42f); //64.18 12.76
    private Vector3Int randomPoint = new Vector3Int(0,0,0);
    private Vector3 randomPoint2 = new Vector3(0, 0, 0);
    private bool[,,] grid = new bool[5, 5, 5];    // Create a 2D grid of booleans

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                //begin
                Debug.Log("Wave Completed");
                nextWave++;
                waveCount.count++;
            }
            else
            {
                return;
            }
        }
        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                if (waves.Length > nextWave)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
                else
                {
                    Debug.Log("You win!");
                    EnemyKilled.Win();
                    gameObject.GetComponent<EnemySpawner>().enabled = false;
                }
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("ENEMY") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        for (int i = 0; i < _wave.count; i++)
        {
            ReturnRandomValueX(i, _wave.count);
            //randomPoint2 = new Vector3((-3 * 14.1f) + randomPoint.x * 14.1f, (5.39f - 7.38f * 3) + randomPoint.y * 7.38f, 12.76f * randomPoint.z);
            randomPoint2 = new Vector3((-3 * 24.1f) + randomPoint.x * 24.1f, (10.39f - 15.38f * 3) + randomPoint.y * 17.38f, 12.76f * randomPoint.z);
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(_wave.rate);
        }
        state = SpawnState.WAITING;

        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, randomPoint2 + spawnPoint, transform.rotation * Quaternion.Euler(0, 0, 0f));
        Debug.Log("Spawning enemy: " + _enemy.name);
    }
    // spawn enemies in random place in 5x5x5 grid
    Vector3Int ReturnRandomValueX(int amount, int amaunt_all)
    {
        randomPoint = new Vector3Int(
        Random.Range(0, 5),
        Random.Range(0, 5),
        Random.Range(0, 5)
        );
        

        if (grid[randomPoint.x, randomPoint.y, randomPoint.z])
        {
            // The point is already taken, generate a new one
            randomPoint = ReturnRandomValueX(amount, amaunt_all);
        }
        else
        {
            // The point is not taken, mark it as taken
            grid[randomPoint.x, randomPoint.y, randomPoint.z] = true;
        }
        return randomPoint;





        /*
                while (takenCells.Count < amaunt_all)
                {
                    // Generate random coordinates
                    int x = Random.Range(0, gridSize);
                    int y = Random.Range(0, gridSize);

                    // Check if the cell is available
                    if (!grid[x, y])
                    {
                        // Mark the cell as taken and add it to the list
                        grid[x, y] = true;
                        takenCells.Add(new Vector2Int(x, y));
                    }
                }

                    randomPoint = new Vector3((-3 * 14.1f) + takenCells[amount].x * 14.1f, (5.39f - 7.38f * 3) + takenCells[amount].y * 7.38f, 0);*/
        //
        //
        //5.39 7.38

        /*        //
                do
                {
                    randomValue = Random.Range(1, 6);
                    pointContained = System.Array.IndexOf(arr1, randomValue) != -1;

                    randomValue2 = Random.Range(1, 6);
                    pointContained2 = System.Array.IndexOf(arr2, randomValue2) != -1;
                } while (pointContained, pointContained2);

                arr1[amount] = randomValue;
                arr2[amount] = randomValue;
                randomPoint = new Vector3((- 3 * 14.1f) + randomValue * (14.1f), 0, 0);*/

       // return randomValue;
    }
    //5x5
}
