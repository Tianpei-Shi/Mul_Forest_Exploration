using UnityEditor;
using UnityEngine;

public class BuildBundle : UnityEditor.Editor
{
	[UnityEditor.MenuItem("Custom/BuildBundles")]
	static void StartBuildBundle()
	{
		//打包
		BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
	}
}
