using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*******************************************************************************
 * 
 *             类名: AssetManager
 *             功能: AssetBundle包资源管理
 *             作者: HGQ
 *             日期: 2016.06.23
 *             修改: 
 *             
 * *****************************************************************************/

public class AssetBundleManager : TSingleton<AssetBundleManager>
{
    AssetBundleManager() { }

    private string bundlePath = "";
    private Dictionary<string, LoadedAssetBundle> loadedBundles = new Dictionary<string, LoadedAssetBundle>();

    /// <summary>
    /// 获取一个LoadedAssetBundle对象，主要是处理WWW加载相关
    /// </summary>
    /// <param name="assetBundleName"></param>
    /// <returns></returns>
    public LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName)
    {
        if (loadedBundles.ContainsKey(assetBundleName))
        {
            loadedBundles[assetBundleName].referencedCount++;
            return loadedBundles[assetBundleName];
        }
        LoadedAssetBundle lab = new LoadedAssetBundle(bundlePath + assetBundleName);
        loadedBundles.Add(assetBundleName, lab);
        return lab;
    }


    public AssetLoader LoadAssetAsync(string assetBundleName, string assetName, System.Type type)
    {
        AssetLoader loader = null;
#if UNITY_EDITOR
        //if (SimulateAssetBundleInEditor)
        //{
        //    string[] assetPaths = AssetDatabase.GetAssetPathsFromAssetBundleAndAssetName(assetBundleName, assetName);
        //    if (assetPaths.Length == 0)
        //    {
        //        Debug.LogError("There is no asset with name \"" + assetName + "\" in " + assetBundleName);
        //        return null;
        //    }

        //    // @TODO: Now we only get the main object from the first asset. Should consider type also.
        //    Object target = AssetDatabase.LoadMainAssetAtPath(assetPaths[0]);
        //    operation = new AssetBundleLoadAssetOperationSimulation(target);
        //}
        //else
#endif
        {
            //LoadAssetBundle(assetBundleName);
            loader = new AssetBundleAssetLoader(assetBundleName, assetName, type);

            //m_InProgressOperations.Add(operation);
        }

        return loader;
    }



}
