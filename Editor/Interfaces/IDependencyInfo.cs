﻿using System.Collections.Generic;
using UnityEditor.Experimental.Build;
using UnityEditor.Experimental.Build.AssetBundle;

namespace UnityEditor.Build.Interfaces
{
    public interface IDependencyInfo : IContextObject
    {
        Dictionary<GUID, AssetLoadInfo> AssetInfo { get; }
        Dictionary<GUID, SceneDependencyInfo> SceneInfo { get; }
        Dictionary<GUID, BuildUsageTagSet> SceneUsage { get; }
        BuildUsageTagGlobal GlobalUsage { get; set; }
    }
}