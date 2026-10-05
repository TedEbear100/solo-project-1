using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();

            StaminaBar = GameObject.Find("StaminaBar").GetComponent<Image>();

            pauseMenu = GameObject.FindGameObjectWithTag("Pause");
            pauseMenu.SetActive(false);
        }
    
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
   

    public void LoadLevel(int levelID)
    {
        if (levelID >= SceneManager.sceneCount)
            Debug.Log("LevelID is too high " + levelID);
        else
            SceneManager.LoadScene(levelID);
    }

    public void LoadNextNevel()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);


    }
    public void MainMenu()
    {
        LoadLevel(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
