using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerConrtoller player;

    public Image HealthBar;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI DetectionMeterText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConrtoller>();

        HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.fillAmount = (float)player.health / (float)player.maxHealth;


    }
}
