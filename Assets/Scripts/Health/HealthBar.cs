using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] Image healthBar;
    [SerializeField] Image healthBarCurrent;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarCurrent.fillAmount = playerHealth.currentHealth / 10;
    }

   
}
