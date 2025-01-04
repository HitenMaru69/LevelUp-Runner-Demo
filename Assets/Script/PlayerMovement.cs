using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float maxXposition = 5;
    private Vector3 startingMousePosition;
    private Vector3 startingPlayerPosition;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startingMousePosition = Input.mousePosition;
            startingPlayerPosition = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition - startingMousePosition;

            float xdir  = mousePos.x / Screen.width * playerSpeed;

            Vector3 newPos = startingPlayerPosition  + new Vector3(xdir, 0, 0);

            newPos.x = Mathf.Clamp(newPos.x, -maxXposition, maxXposition);

            transform.position = newPos;
        }

    }

}
