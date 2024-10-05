using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;      // ������ ��� ������ ��� �������
    public int poolSize = 10;      // ������ ����
    private Queue<GameObject> pool; // ������� �������� � ����

    private void Start()
    {
        pool = new Queue<GameObject>();

        // ������������� ���� ��������
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.SetParent(transform);  // ������������� ��������� ���� ���
            pool.Enqueue(obj);
        }
    }

    // ����� ��� ��������� ������� �� ����
    public GameObject GetFromPool()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            obj.transform.SetParent(transform);  // ��������� ������� �������� - ���
            return obj;
        }
        else
        {
            // ���� ��� ����, ������ ����� ������, �� �� ����� ��������� ��� ��������� ���� ���
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(transform);  // ������������� ��������� ���� ���
            return obj;
        }
    }

    // ����������� ������� ������� � ���
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
        obj.transform.SetParent(transform);  // ����� ��������� ��������� ���� ��� ��� ��������
    }
}
