using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelScript : MonoBehaviour
{
    public float startTime = 20f;
    public float maxTime = 100f; 
    public TMP_Text textMesh;
    public GameObject endGamePopup;
    public TMP_Text endGameText; // Reference to the EndGameText TMP_Text component
    public TMP_Text waveText;
    public float currentTime;
    private bool isPaused = false;
    public Button MenuButton;
    public Image TimeBarFill; 
    public GameObject healthBar; 

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        UpdateTimerText();
        StartCoroutine(StartTimer());

        MenuButton.onClick.AddListener(GoToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > maxTime)
        {
            currentTime = maxTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            TimeBarFill.fillAmount = currentTime / 100f;
            if (!isPaused)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        EndGame("Out of Fuel"); 
    }

    void UpdateTimerText()
    {
        if (textMesh != null)
        {
            textMesh.text = Mathf.CeilToInt(currentTime).ToString();
        }
    }

    public void EndGame(string endGameReason)
    {
        endGameText.text = endGameReason; // Set the EndGameText based on the endGameReason

        endGamePopup.SetActive(true);
        Time.timeScale = 0f; // Pause the scene
    }

    public void WaveCounter(int waveCount)
    {
        waveText.text = "Wave: " + waveCount; 
    }
    public void BossWave()
    {
        waveText.text = "Wave: Boss"; 
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f; // Pause or resume the scene
    }

    public void GoToMenu()
    {
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
        UpdateTimerText();
    }

    public void SubtractTime(float amount)
    {
        currentTime -= amount;
        UpdateTimerText();
    }

    public void DisplayBossHealth()
    {
        healthBar.SetActive(true);
    }
}

