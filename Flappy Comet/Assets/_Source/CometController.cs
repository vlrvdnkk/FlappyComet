using UnityEngine;
using UnityEngine.SceneManagement;

public class CometController : MonoBehaviour
{
    public float jumpForce = 5f;     // Сила прыжка
    private Rigidbody2D rb;          // Компонент Rigidbody2D для управления физикой

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        // Применяем силу вверх для прыжка
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void GravityOn()
    {
        rb.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем столкновение с врагом или стенами (пол и потолок)
        if (collision.gameObject)
        {
            RestartScene();  // Перезапуск сцены при столкновении с врагом или стенами
        }
    }

    private void RestartScene()
    {
        // Перезапуск текущей сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
