using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : Singleton<ObjectPool>
{
    [System.Serializable] internal class ObjectList<T> where T : UnityEngine.Object
    {
        public ObjectList(){}
        public ObjectList(List<T> list, T prefab, int amtToPool) { SetList(list); SetPrefab(prefab); SetAmtToPool(amtToPool); }
        List<T> _pooledObjects = new List<T>();
        [SerializeField] T _prefab;
        [SerializeField] int _amtToPool = 0;
        public int Count { get => _pooledObjects.Count; set {; } }

        //OVERLOAD OPERATOR SO YOU DON'T HAVE TO ACCESS _pooledObjects VARIABLE
        public T this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }

        //GETTERS & SETTERS
        public void SetList(List<T> list) { list = _pooledObjects; }
        public void SetPrefab(T prefab) { _prefab = prefab; }
        public void SetAmtToPool(int amt) { _amtToPool = amt; }
        public void SetValue(int key, T value) { _pooledObjects[key] = value; }

        public T GetPrefab() { return _prefab; }
        public T GetValue(int key) { return _pooledObjects[key]; }
        public int GetAmtToPool() { return _amtToPool; }
        public void Add(T value) { _pooledObjects.Add(value); }
        
    }

    [SerializeField] ObjectList<GameObject> genericsTest = new ObjectList<GameObject>();
    [SerializeField] ObjectList<AudioSource> genericsTestAudio = new ObjectList<AudioSource> (); 

    void Start()
    {
        FillPool(genericsTest);
        FillPool(genericsTestAudio);

        GetPooled(genericsTestAudio);
        GetPooled(genericsTest);
    }

    void FillPool<T>(ObjectList<T> data) where T : UnityEngine.Component
    {
        for(int i = 0; i < data.GetAmtToPool(); ++i)
        {
            T obj = Instantiate(data.GetPrefab(), gameObject.transform);
            obj.gameObject.SetActive(false);
            data.Add(obj);
        }
    }

    void FillPool(ObjectList<GameObject> data)
    {
        for (int i = 0; i < data.GetAmtToPool(); ++i)
        {
            GameObject obj = Instantiate(data.GetPrefab(), gameObject.transform);
            obj.gameObject.SetActive(false);
            data.Add(obj);
        }
    }

    T GetPooled<T>(ObjectList<T> data) where T : UnityEngine.Component
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (!data[i].gameObject.activeInHierarchy) return data[i];
        }

        T inst = Instantiate(data.GetPrefab()); //this needs to know WHICH _prefab to instantiate
        inst.gameObject.SetActive(false);
        data.Add(inst);
        return inst;
    }

    GameObject GetPooled(ObjectList<GameObject> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            if (!data[i].gameObject.activeInHierarchy) return data[i];
        }

        GameObject inst = Instantiate(data.GetPrefab()); //this needs to know WHICH _prefab to instantiate
        inst.gameObject.SetActive(false);
        data.Add(inst);
        return inst;
    }
}