using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public float moveSpeed = 3f;        // Скорость движения бонуса
    public float attractSpeed = 5f;
    public float destroyDistance = 0.1f; // Минимальное расстояние для уничтожения бонуса

    private Transform cometTransform;
    private bool isAttracting = false; // Флаг для проверки начала притяжения

    private void Start()
    {
        cometTransform = GameObject.FindGameObjectWithTag("Comet").transform;
    }

    private void Update()
    {
        if (isAttracting && cometTransform != null)
        {
            // Притягиваем бонус к комете
            transform.position = Vector3.MoveTowards(transform.position, cometTransform.position, attractSpeed * Time.deltaTime);

            // Проверяем расстояние между бонусом и кометой для уничтожения
            if (Vector3.Distance(transform.position, cometTransform.position) < destroyDistance)
            {
                // Добавляем очки и уничтожаем бонус
                GameController.Instance.AddScore(1);
                Destroy(gameObject);
            }
        }
        else
        {
            // Бонус продолжает двигаться по прямой траектории влево
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Когда комета входит в триггер-зону, начинаем притяжение
        if (other.CompareTag("Comet"))
        {
            isAttracting = true;
        }
    }
}