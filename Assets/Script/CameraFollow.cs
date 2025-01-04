using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Vector3 offSet;
    [SerializeField] float speed;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 smoothPos = Vector3.Lerp(transform.position,target.transform.position + offSet, speed);
            transform.position = smoothPos;
        }
    }

}
