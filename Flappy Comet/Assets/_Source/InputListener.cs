using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private CometController _cometController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            _cometController.Jump();
        }
    }
}
