using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance = null;

    public static T Instance { get { return GetSingleton(); } }

    internal void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = gameObject.GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (this == _instance)
        {
            _instance = null;
        }
    }

    //probably wouldnt ever work since each singleton/manager typically has predefined gameobject fields that wont be added when the component is added
    internal static T GetSingleton()
    {
        if (_instance == null)
        {
            GameObject singleton = new GameObject();
            singleton.name = typeof(T).Name;
            _instance = singleton.AddComponent<T>();
            DontDestroyOnLoad(singleton);
            return _instance;
        }
        else return _instance;
    }
}