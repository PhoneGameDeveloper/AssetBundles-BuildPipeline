﻿using System;
using System.Collections.Generic;
using UnityEditor.Experimental.Build;
using UnityEditor.Experimental.Build.AssetBundle;

namespace UnityEditor.Build
{
    public interface IBundlesInput
    {
        BuildInput BundleInput { get; }
    }

    public interface IDependencyCallback
    {
        Func<IBuildParams, IDependencyInfo, BuildPipelineCodes> PostDependencyCallback { get; }
    }

    public interface IDependencyInfo
    {
        Dictionary<GUID, AssetLoadInfo> AssetInfo { get; }
        Dictionary<GUID, SceneDependencyInfo> SceneInfo { get; }
        Dictionary<GUID, string> SceneAddress { get; }
        Dictionary<GUID, BuildUsageTagSet> SceneUsage { get; }
        BuildUsageTagGlobal GlobalUsage { get; set; }
        Dictionary<GUID, List<string>> AssetToBundles { get; }
        Dictionary<string, List<GUID>> BundleToAssets { get; }
    }

    public class BuildContext : IBundlesInput, IDependencyInfo
    {
        public BuildInput BundleInput { get; set; }

        public Dictionary<GUID, AssetLoadInfo> AssetInfo { get { return dependencyData.assetInfo; } }
        public Dictionary<GUID, SceneDependencyInfo> SceneInfo { get { return dependencyData.sceneInfo; } }
        public Dictionary<GUID, string> SceneAddress { get { return dependencyData.sceneAddress; } }
        public Dictionary<GUID, BuildUsageTagSet> SceneUsage { get { return dependencyData.sceneUsageTags; } }
        public BuildUsageTagGlobal GlobalUsage
        {
            get { return dependencyData.buildGlobalUsage; }
            set { dependencyData.buildGlobalUsage = value; }
        }
        public Dictionary<GUID, List<string>> AssetToBundles { get { return dependencyData.assetToBundles; } }
        public Dictionary<string, List<GUID>> BundleToAssets { get { return dependencyData.bundleToAssets; } }

        // TODO: Replace these classes maybe?
        private BuildDependencyInfo dependencyData = new BuildDependencyInfo();
        private BuildWriteInfo writeInfo = new BuildWriteInfo();
        private BuildResultInfo resultInfo = new BuildResultInfo();
    }
}