using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float m_currentTime = 0.0f;
    private float m_startingTime = 10.0f;

    [SerializeField] Text countdownText; // priverčia Unity serializuoti privatų lauką

    private void Start()
    {
        m_currentTime = m_startingTime;
    }

    private void Update()
    {
        m_currentTime -= 1 * Time.deltaTime;
        countdownText.text = m_currentTime.ToString("0");

        if(m_currentTime <= 0)
        {
            m_currentTime = 0;
        }
    }
}
