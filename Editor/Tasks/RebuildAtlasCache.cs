﻿using System;
using UnityEditor.Build.Interfaces;
using UnityEditor.Sprites;

namespace UnityEditor.Build.Tasks
{
    public struct RebuildAtlasCache : IBuildTask
    {
        const int k_Version = 1;
        public int Version { get { return k_Version; } }

        static readonly Type[] k_RequiredTypes = { typeof(IBuildParams) };
        public Type[] RequiredContextTypes { get { return k_RequiredTypes; } }

        public BuildPipelineCodes Run(IBuildContext context)
        {
            return Run(context.GetContextObject<IBuildParams>());
        }

        public static BuildPipelineCodes Run(IBuildParams buildParams)
        {
            // TODO: Need a return value if this ever can fail
            Packer.RebuildAtlasCacheIfNeeded(buildParams.BundleSettings.target, true, Packer.Execution.Normal);
            return BuildPipelineCodes.Success;
        }
    }
}