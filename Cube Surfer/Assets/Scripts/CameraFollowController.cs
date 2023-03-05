
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float lerpValue;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        SetCameraFollow();
    }

    void SetCameraFollow()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, new Vector3(0f, playerTransform.position.y, playerTransform.position.z) + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
