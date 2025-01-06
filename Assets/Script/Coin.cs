using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    private void Update()
    {
        transform.Rotate(0f,rotationSpeed *  Time.deltaTime,0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(NameTag.Player))
        {
            PlayerMovement playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            playerMovement.UpdateLevelText();
            Destroy(gameObject);
            
        }
    }

}
