using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public float moveSpeed = 3f;        // �������� �������� ������
    public float attractSpeed = 5f;
    public float destroyDistance = 0.1f; // ����������� ���������� ��� ����������� ������

    private Transform cometTransform;
    private bool isAttracting = false; // ���� ��� �������� ������ ����������

    private void Start()
    {
        cometTransform = GameObject.FindGameObjectWithTag("Comet").transform;
    }

    private void Update()
    {
        if (isAttracting && cometTransform != null)
        {
            // ����������� ����� � ������
            transform.position = Vector3.MoveTowards(transform.position, cometTransform.position, attractSpeed * Time.deltaTime);

            // ��������� ���������� ����� ������� � ������� ��� �����������
            if (Vector3.Distance(transform.position, cometTransform.position) < destroyDistance)
            {
                // ��������� ���� � ���������� �����
                GameController.Instance.AddScore(1);
                Destroy(gameObject);
            }
        }
        else
        {
            // ����� ���������� ��������� �� ������ ���������� �����
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����� ������ ������ � �������-����, �������� ����������
        if (other.CompareTag("Comet"))
        {
            isAttracting = true;
        }
    }
}