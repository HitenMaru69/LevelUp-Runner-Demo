using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyType
{
    normal,
    main
}

public class Enemy : MonoBehaviour
{
    
    [SerializeField] Animation enemyAnimation;
    [SerializeField] AnimationClip idleClip;
    [SerializeField] AnimationClip punchClip;
    [SerializeField] AnimationClip deathClip;

    [SerializeField] TextMeshPro txt;
    [SerializeField] int level;

    public EnemyType enemyType;

    bool isMainEnemyKill;

    private void Start()
    {
        enemyAnimation.Play(idleClip.name);
        txt.text = "Level:" + level;

        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(NameTag.Player))
        {
            if(enemyType == EnemyType.main)
            {
                PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();

                if (playerMovement.currentLevel >= level)
                {
                    // Play Animation
                    playerMovement.MainEnemyPunch();
                    StartCoroutine(EnemyDeath());

                    // Set Player Level
                    playerMovement.currentLevel = playerMovement.incressLevel;
                    playerMovement.currentLevel+=1;
                    PlayerPrefs.SetInt(NameTag.PlayerLevel, playerMovement.currentLevel);

                    // Set Next Level
                    GameManager.instance.IncreesLevel();

                }
                else
                {
                    GameManager.instance.CallPlayerDieEvent();
                    enemyAnimation.Play(punchClip.name);
                }

            }
            else
            {
                // For Normal Enemy

                PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();

                if (playerMovement.currentLevel > level)
                {
                    playerMovement.PlayPunchAnimation();
                    enemyAnimation.Play(deathClip.name);
                    Destroy(gameObject, enemyAnimation[deathClip.name].length);
                }
                else
                {               
                    GameManager.instance.CallPlayerDieEvent();
                    enemyAnimation.Play(punchClip.name);
                }
            }



        }
    }

  



    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(1f);
        enemyAnimation.Play(deathClip.name);
        yield return new WaitForSeconds(enemyAnimation[deathClip.name].length);
        GameManager.instance.ShowNextLevelCanvas(enemyAnimation[deathClip.name].length);
    }
}
