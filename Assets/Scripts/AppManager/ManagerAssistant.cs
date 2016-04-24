using UnityEngine;
using System.Collections;


/// 管理器助手类
public class ManagerAssistant : MonoBehaviour
{

    private static ManagerAssistant mInstance;

    public static void Init()
    {
        if (mInstance == null)
        {
            GameObject go = new GameObject("ManagerAssistant");
            GameObject.DontDestroyOnLoad(go);
            mInstance = go.AddComponent<ManagerAssistant>();
        }

        AddManager<ResourceUpdateManager>("ResourceUpdateManager");
    }

    /// <summary>
    /// 添加组件管理器
    /// </summary>
    static void AddManager<T>(string typeName) where T : Component
    {
        GameObject go = new GameObject(typeName);
        Component component = Tools.GetComponentSafe<T>(go);

        if (component == null) {
            Debug.LogError("[ManagerAssistant > AddManager > Add Component Failure]");
        }

        //设置管理器父级
        if (mInstance.gameObject != null)
        {
            go.transform.parent = mInstance.gameObject.transform;
        }
        else
        {
            GameObject.DontDestroyOnLoad(go);
        }
    }
}
