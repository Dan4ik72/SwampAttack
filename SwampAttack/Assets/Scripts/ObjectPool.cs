using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool: MonoBehaviour
{
    [SerializeField] private List<GameObject> _pool;

    [SerializeField] private GameObject _parent;

    public void Create(GameObject prefab, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject created = Instantiate(prefab, _parent.transform);

            created.SetActive(false);

            _pool.Add(created); 
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
