using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event EventHandler PlayerDie;

    public Canvas gameOverCanvas;
    public Canvas nextLevelCanvas;
    public Canvas playCanvas;

    public Levels levels; // All Levels Which is in the Scriptable object

    public int levelCount = 0;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        gameOverCanvas.enabled = false;
        nextLevelCanvas.enabled = false;
        playCanvas.enabled = true;

        levelCount = PlayerPrefs.GetInt(NameTag.loadLevel, 0);

        if(levels.ground.Count > levelCount)
        {
            Instantiate(levels.ground[levelCount].gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
            Time.timeScale = 0f;
        }
    }



    public void CallPlayerDieEvent()
    {
        PlayerDie?.Invoke(this,EventArgs.Empty);
    }

    public void IncreesLevel()
    {
        levelCount += 1;
        PlayerPrefs.SetInt(NameTag.loadLevel, levelCount);
    }


    // For UI

    public void ShowGameOverCanvas(float time)
    {
        StartCoroutine(waitForCanvasShow(time));
    }

    public void ShowNextLevelCanvas(float time)
    {
        StartCoroutine(waitForWinnerCanvasShow(time));
    }

    IEnumerator waitForCanvasShow(float time)
    {
        yield return new WaitForSeconds(time);

        gameOverCanvas.enabled = true;
    }

    IEnumerator waitForWinnerCanvasShow(float time)
    {
        yield return new WaitForSeconds(time);
        nextLevelCanvas.enabled = true;
    }

    public void RestartBu()
    {
        SceneManager.LoadScene(NameTag.GamePlayScene);
    }

    public void PlayBU()
    {
        playCanvas.enabled = false;
        Time.timeScale = 1f;
    }

}
