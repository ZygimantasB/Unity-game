using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class SpawnMagager : MonoBehaviour
{

    public GameObject enemyPrefab; // Pridedu priešą 
    public GameObject catcherPrefab; 
    public Vector2 spawnRangeX;

    private float m_SpawnIntervalEnemy = 0.25f;
    private float m_SpawnIntervalCatcher = 2.5f;
    private float m_Timer = 0;
    private float m_TimerCatcher = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEvader", m_Timer, m_SpawnIntervalEnemy);
        InvokeRepeating(nameof(SpawnCatcher), m_TimerCatcher, m_SpawnIntervalCatcher);
    }

    private void SpawnCatcher()
    {
        SpawnEnemy(EnemyType.Catcher);
    }
    private void SpawnEvader()
    {
        SpawnEnemy(EnemyType.Evader);
    }
    private void SpawnEnemy(EnemyType enemyType)
    {

        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeX[0], spawnRangeX[1]), // Mes šias reikšmes paimama iš unity programos t.y. -7,75 ir 7,75
            enemyPrefab.transform.position.y,
            enemyPrefab.transform.position.z);

        if (enemyType == EnemyType.Evader)
        {
            Instantiate(
            enemyPrefab,
            spawnPosition, // duoda random poziciją poziciją
            enemyPrefab.transform.rotation); // duoda pradinę rotaciją
        }
        else if (enemyType == EnemyType.Catcher)
        {
            Instantiate(
                catcherPrefab,
                spawnPosition, // duoda random poziciją poziciją
                catcherPrefab.transform.rotation); // duoda pradinę rotaciją
        }
    }
}
