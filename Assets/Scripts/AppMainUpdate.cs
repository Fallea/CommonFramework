using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*******************************************************************************
 * 
 *             类名: AppMainUpdate
 *             功能: 主更新循环类，管理整个运行流程和操作等控制
 *             作者: HGQ
 *             日期: 2016.4.22
 *             修改:
 *             
 * *****************************************************************************/

public class AppMainUpdate : MonoBehaviour
{

    void Start()
    {
        ManagerAssistant.Instance.Initialize();
    }

    void Update()
    {

    }

    /// <summary>
    /// APP暂停时相应（移动平台退出到后台）
    /// </summary>
    /// <param name="paused"></param>
    void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            Debug.Log("[App Pause]");
        }
        else
        {
            Debug.Log("[App Resume]");
        }
    }

    /// <summary>
    /// APP结束时调用
    /// </summary>
    void OnApplicationQuit()
    {
        Debug.Log("[App End]");
    }
}
