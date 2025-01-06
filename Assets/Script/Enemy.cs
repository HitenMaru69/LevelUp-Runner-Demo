using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animation enemyAnimation;
    [SerializeField] AnimationClip idleClip;
    [SerializeField] AnimationClip punchClip;
    [SerializeField] AnimationClip deathClip;


    private void Start()
    {
        enemyAnimation.Play(idleClip.name);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(NameTag.Player))
        {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.PlayPunchAnimation();
            enemyAnimation.Play(deathClip.name);
            Destroy(gameObject,enemyAnimation[deathClip.name].length);
        }
    }

  
}
