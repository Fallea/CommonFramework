using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 委托事件处理中心
/// </summary>
public class DelegateManager
{
    private static DelegateManager mInstance;

    public static DelegateManager Instance
    {
        get
        {
            return mInstance;
        }
    }

    static DelegateManager()
    {
        mInstance = new DelegateManager();
    }

    //================================================================
    /// <summary>
    /// 无返回参数
    /// </summary>
    private Dictionary<DelegateCommand, Action> voidActions = new Dictionary<DelegateCommand, Action>();

    /// <summary>
    /// 注册委托指令
    /// </summary>
    public void AddListener(DelegateCommand command, Action callback)
    {
        if (voidActions.ContainsKey(command))
        {
            voidActions[command] += callback;
        }
        else
        {
            voidActions.Add(command, callback);
        }
    }

    /// <summary>
    /// 移除委托指令
    /// </summary>
    public void RemoveListener(DelegateCommand command, Action callback)
    {
        if (voidActions.ContainsKey(command))
        {
            voidActions[command] -= callback;
        }
    }

    /// <summary>
    /// 派发指令
    /// </summary>
    public void Dispatch(DelegateCommand command)
    {
        if (voidActions.ContainsKey(command))
        {
            voidActions[command].Invoke();
        }
    }

    //================================================================
    /// <summary>
    /// 带返回参数
    /// </summary>
    private Dictionary<DelegateCommand, Action<object>> objectActions = new Dictionary<DelegateCommand, Action<object>>();

    /// <summary>
    /// 注册委托指令
    /// </summary>
    public void AddListener(DelegateCommand command, Action<object> callback)
    {
        if (objectActions.ContainsKey(command))
        {
            objectActions[command] += callback;
        }
        else
        {
            objectActions.Add(command, callback);
        }
    }

    /// <summary>
    /// 移除委托指令
    /// </summary>
    public void RemoveListener(DelegateCommand command, Action<object> callback)
    {
        if (objectActions.ContainsKey(command))
        {
            objectActions[command] -= callback;
        }
    }

    /// <summary>
    /// 派发指令
    /// </summary>
    public void Dispatch(DelegateCommand command, object obj)
    {
        if (objectActions.ContainsKey(command))
        {
            objectActions[command].Invoke(obj);
        }
    }

}