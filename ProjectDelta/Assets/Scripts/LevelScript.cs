using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelScript : MonoBehaviour
{
    public float timerDuration = 30f;
    public Text timerText;
    public GameObject timesUpPopup;
    private float currentTime;
    private bool isPaused = false;
    public Button MenuButton;

    // Start is called before the first frame update
    void Start()
    {

        currentTime = timerDuration;
        UpdateTimerText();
        StartCoroutine(StartTimer());

        MenuButton.onClick.AddListener(GoToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            if (!isPaused)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            yield return null;
        }

        TimeUp();
    }

    void UpdateTimerText()
    {
        if (timerText != null) 
        {
        timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
        }
    }

    void TimeUp()
    {
        timesUpPopup.SetActive(true);
        Time.timeScale = 0f; // Pause the scene
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
}

/*
    ADD AT THE TOP
    private LevelScript levelScript;

    private void Start()
    {
        levelScript = GameObject.FindObjectOfType<LevelScript>();
    }

    private void OnDestroy()
    {
        levelScript.AddTime(10f);
    }

*/
