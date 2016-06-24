using UnityEngine;
using System;
using System.Collections.Generic;


public class LoadTest : MonoBehaviour
{
    void Start()
    {
        ResourceLoadManager.Instance.LoadAssetAsync<GameObject>("Prefabs/Cube", (obj)=> 
        {
            GameObject go = GameObject.Instantiate(obj);
        });

        ResourceLoadManager.Instance.LoadAssetAsync<GameObject>("Prefabs/Cube", (obj) =>
        {
            GameObject go = GameObject.Instantiate(obj);
        });
    }
}
