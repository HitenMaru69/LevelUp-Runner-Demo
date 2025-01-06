using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event EventHandler PlayerDie;

    public Canvas gameOverCanvas;
    public Canvas nextLevelCanvas;

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        gameOverCanvas.enabled = false;
        nextLevelCanvas.enabled = false;
    }

    public void RestartBu()
    {
        SceneManager.LoadScene(NameTag.GamePlayScene);
    }

    public void CallPlayerDieEvent()
    {
        PlayerDie?.Invoke(this,EventArgs.Empty);
    }


    public void ShowGameOverCanvas(float time)
    {
        StartCoroutine(waitForCanvasShow(time));
    }

    IEnumerator waitForCanvasShow(float time)
    {
        yield return new WaitForSeconds(time);

        gameOverCanvas.enabled = true;
    }
    
}
