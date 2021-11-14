using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform leftwall;
    public Transform rightwall;
    private Stats m_Stats;
    public HUDManager hudMananger;

    private void Awake()
    {
        m_Stats = GetComponent<Stats>();
        hudMananger.UpdateHealthText(m_Stats.health); 
    }

    // if FPS is 150 then update is callrd 150 and postion is changed by 150
    private void Update() // Update  funckijoje mes įvesime Player judėjimus
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float horizontalPosition = transform.position.x + horizontalInput * speed * Time.deltaTime;

        float playerSize = transform.localScale.x / 2;

        if (horizontalPosition - playerSize <= leftwall.position.x + leftwall.localScale.x / 2) // Daliname i6 dviejų, nes mano veikėjo centras yra ne nuo krašto, o nuo vidurio. 
        {
            return;
        }
        if (horizontalPosition + playerSize >= rightwall.position.x - rightwall.localScale.x / 2)
        {
            return;
        }


        transform.position = new Vector3(
            horizontalPosition,
            1, 
            transform.position.z);
    }

    public void ReceivDamage()
    {
        m_Stats.UpdateHealth(10);
        hudMananger.UpdateHealthText(m_Stats.health);
    }
}
 