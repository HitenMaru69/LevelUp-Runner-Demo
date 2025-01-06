using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] Transform wayPos;
   
    public GameObject mainEnemy;



    private void Update()
    {
        if (mainEnemy.transform.position != wayPos.position)
        {
            mainEnemy.transform.position = Vector3.MoveTowards(mainEnemy.transform.position, wayPos.position, 50 * Time.deltaTime);
        }
    }

}
