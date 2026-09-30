using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController player;

    public Image HealthBar;
    public Image StaminaBar;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI DetectionMeterText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();

        StaminaBar = GameObject.Find("StaminaBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.fillAmount = (float)player.health / (float)player.maxHealth;

        StaminaBar.fillAmount = (float)player.stamina / (float)player.maxStamina;
    }
}
