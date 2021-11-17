using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Catcher,
    Evader 
}

public class EnemyController : MonoBehaviour
{
    public float speed;
    public EnemyType enemyType;

    private readonly float m_TresholdPositionZ = -25.5f;
    private PlayerController m_PlayerC;

    private void Start()
    {
        m_PlayerC = GameObject
            .Find("Player")
            .GetComponent<PlayerController>();
    }
    private void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - speed * Time.deltaTime);

        // atskaičiuoti atstumą tarp prie6o ir veik4jo pozicijos

        if (Vector3.Distance(m_PlayerC.transform.position, transform.position) < 1.0f)
        {
            if (enemyType == EnemyType.Evader)
            {
                m_PlayerC.ReceivDamage();
            }
            Destroy(gameObject);
        }

        else if (m_PlayerC.transform.position.z - transform.position.z > 5.0f && enemyType == EnemyType.Catcher)
        {
            m_PlayerC.ReceivDamage();
            Destroy(gameObject);
        }

        if (transform.position.z <= m_TresholdPositionZ)
        {
            Destroy(gameObject);
        }
    }
}
