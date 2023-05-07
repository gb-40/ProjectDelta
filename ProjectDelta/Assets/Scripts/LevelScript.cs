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
    public GameObject timesUpPopup;
    private float currentTime;
    private bool isPaused = false;
    public Button MenuButton;
    public Image TimeBarFill; 

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
        if(currentTime > maxTime)
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
            TimeBarFill.fillAmount = currentTime/100f;
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
        
        if (textMesh != null) 
        {
        textMesh.text = Mathf.CeilToInt(currentTime).ToString();
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
