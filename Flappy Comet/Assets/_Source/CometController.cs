using UnityEngine;
using UnityEngine.SceneManagement;

public class CometController : MonoBehaviour
{
    public float jumpForce = 5f;     // ���� ������
    private Rigidbody2D rb;          // ��������� Rigidbody2D ��� ���������� �������

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        // ��������� ���� ����� ��� ������
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void GravityOn()
    {
        rb.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��������� ������������ � ������ ��� ������� (��� � �������)
        if (collision.gameObject)
        {
            RestartScene();  // ���������� ����� ��� ������������ � ������ ��� �������
        }
    }

    private void RestartScene()
    {
        // ���������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
