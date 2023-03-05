
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerInputController playerInputController;
    [SerializeField] float forwardSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float horizontalLimit;

    float newPositionX;
    
    void FixedUpdate()
    {
        SetForwardMovement();
        SetHorizontalMovement();
    }

    void SetForwardMovement()
    {
        transform.Translate(Vector3.down * forwardSpeed * Time.fixedDeltaTime);
    }

    void SetHorizontalMovement()
    {
        newPositionX = transform.position.x + playerInputController.HorizontalValue * horizontalSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimit, horizontalLimit);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Invoke("Reset", 2f);
        }
    }
    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
