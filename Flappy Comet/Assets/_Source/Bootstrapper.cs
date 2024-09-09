using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private CometController _cometController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _startText.SetActive(false);
            _cometController.GravityOn();
        }
    }
}
