using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text health;

    public void UpdateHealthText(float health)
    {
        this.health.text = "Health " + health;
    }
}
