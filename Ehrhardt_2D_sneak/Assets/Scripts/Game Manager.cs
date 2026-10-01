using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagment;


public class GameManager : MonoBehaviour
{
    
    public PlayerController player;

    public Image HealthBar;
    public Image StaminaBar;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI DetectionMeterText;
    public GameObject pauseMenu;
    
    public bool paused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManger.getActivescene
            )
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();

        StaminaBar = GameObject.Find("StaminaBar").GetComponent<Image>();

        pauseMenu = GameObject.FindGameObjectWithTag("Pause");
        pauseMenu.SetActive(false);

    
    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.fillAmount = (float)player.health / (float)player.maxHealth;

        StaminaBar.fillAmount = (float)player.stamina / (float)player.maxStamina;
    }

    public void pause()
    {
        paused = !paused;

        pauseMenu.SetActive(paused);

        if (paused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;

            pauseMenu.SetActive(false);


        }
    
    }


    public void Loadlevel(int levelID)
    {
        if (levelID >= SceneManger.sceneCount)
            Debug.Log("LevelID is too high " + levelID);
        else
            SceneManager.Loadscene(levelID);
    }

    public void LoadNextNevel()
    {
        Loadscene;


    }
    public void MainMenu()
    {
        Loadlevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
