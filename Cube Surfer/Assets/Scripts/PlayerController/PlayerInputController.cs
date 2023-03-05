
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    float horizontalValue;
    public float HorizontalValue { get { return horizontalValue; } }

    void Update()
    {
        HandlePlayerHorizontal();
    }

    void HandlePlayerHorizontal()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
    }

}
