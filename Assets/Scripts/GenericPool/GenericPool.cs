using AbstractFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenericPool
{
    public class GenericPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        public List<T> pooledItems = new List<T>();
        public int initItemCount;
        [SerializeField]protected AbstractFactory<T> itemFactory;
        public bool isExpandable = false;

        protected virtual void Awake()
        {
            for (int i = 0; i < initItemCount; i++)
            {
                var item = itemFactory.GetNewInstance();
                pooledItems.Add(item);
                item.gameObject.SetActive(false);
            }
        }
        public T GetItemFromPool()
        {
            if (pooledItems.Count > 0)
            {
                T toReturn = pooledItems[0];
                pooledItems.Remove(pooledItems[0]);
                return toReturn;
            }
            else if (isExpandable)
            {
                return itemFactory?.GetNewInstance();
            }
            return null;
        }

        public void ReturnItemToPool(T item)
        {
            pooledItems.Add(item);
            item.gameObject.SetActive(false);
        }
    }

}