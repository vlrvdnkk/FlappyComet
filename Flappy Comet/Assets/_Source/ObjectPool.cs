using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;      // Префаб для врагов или бонусов
    public int poolSize = 10;      // Размер пула
    private Queue<GameObject> pool; // Очередь объектов в пуле

    private void Start()
    {
        pool = new Queue<GameObject>();

        // Инициализация пула объектов
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.SetParent(transform);  // Устанавливаем родителем этот пул
            pool.Enqueue(obj);
        }
    }

    // Метод для получения объекта из пула
    public GameObject GetFromPool()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            obj.transform.SetParent(transform);  // Назначаем объекту родителя - пул
            return obj;
        }
        else
        {
            // Если пул пуст, создаём новый объект, но всё равно назначаем его родителем этот пул
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(transform);  // Устанавливаем родителем этот пул
            return obj;
        }
    }

    // Возвращение объекта обратно в пул
    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
        obj.transform.SetParent(transform);  // Снова назначаем родителем этот пул при возврате
    }
}
