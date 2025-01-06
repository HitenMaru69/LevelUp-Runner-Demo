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

    [SerializeField] EnemyType enemyType;

    private void OnEnable()
    {
        GameManager.instance.PlayerDie += PlayPunchAnimation;
    }



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
                // Main Enemy 
            }
            else
            {
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
                }
            }



        }
    }

    private void PlayPunchAnimation(object sender, System.EventArgs e)
    {
        enemyAnimation.Play(punchClip.name);
    }

    private void OnDisable()
    {
        GameManager.instance.PlayerDie -= PlayPunchAnimation;
    }
}
