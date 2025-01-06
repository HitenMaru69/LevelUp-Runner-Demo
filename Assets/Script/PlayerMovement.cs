using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float playerRunSpeed;
    [SerializeField] float maxXposition = 5;
    [SerializeField] Animation animation;
    [SerializeField] AnimationClip runClip;
    [SerializeField] AnimationClip punchClip;
    [SerializeField] AnimationClip deathClip;

    private Vector3 startingMousePosition;
    private Vector3 startingPlayerPosition;
    private float originalRunSpeed;


    private void Start()
    {
        PlayAnimation(runClip.name);
        originalRunSpeed = playerRunSpeed;
        

    }


    private void Update()
    {

        RunPlayer();

        
        if (Input.GetMouseButtonDown(0))
        {
            startingMousePosition = Input.mousePosition;
            startingPlayerPosition = transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            LeftRighMovement();          
        }

    }

    void LeftRighMovement()
    {
        

        Vector3 mousePos = Input.mousePosition - startingMousePosition;

        float xdir = mousePos.x / Screen.width * playerSpeed;

        Vector3 newPos = transform.position;
            
        newPos.x = startingPlayerPosition.x + xdir;

        newPos.x = Mathf.Clamp(newPos.x, -maxXposition, maxXposition);

        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);


    }

    void RunPlayer()
    {
        transform.Translate(Vector3.forward * playerRunSpeed * Time.deltaTime);
    }

    
    public void PlayAnimation(string clip)
    {
        animation.Play(clip);
    }

    public void PlayPunchAnimation()
    {
        StartCoroutine(PunchAnimation(punchClip));
    }

    IEnumerator PunchAnimation(AnimationClip clip)
    {
        playerRunSpeed = 2f;

        animation.Play(clip.name);

        yield return new WaitForSeconds(animation[clip.name].length);

        playerRunSpeed = originalRunSpeed;

        animation.Play(runClip.name);
    }


}
