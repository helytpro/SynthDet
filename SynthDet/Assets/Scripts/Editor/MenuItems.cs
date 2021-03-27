﻿using SynthDet.Randomizers;
using SynthDet.Scenarios;
using UnityEditor;
using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers;
using UnityEngine.Perception.Randomization.Scenarios;
using BackgroundObjectPlacementRandomizer = SynthDet.Randomizers.BackgroundObjectPlacementRandomizer;
using ForegroundObjectPlacementRandomizer = SynthDet.Randomizers.ForegroundObjectPlacementRandomizer;

namespace SynthDet
{
    public static class MenuItems
    {
        [MenuItem("SynthDet/Create Default Scenario")]
        static void CreateDefaultScenario()
        {
            var scenarioObj = new GameObject("Scenario");

            var scenario = scenarioObj.AddComponent<SynthDetScenario>();
            scenario.constants.totalIterations = 1000;
            
            scenario.AddRandomizer(new BackgroundObjectPlacementRandomizer());
            scenario.AddRandomizer(new ForegroundObjectPlacementRandomizer());
            scenario.AddRandomizer(new ForegroundOccluderPlacementRandomizer());
            scenario.AddRandomizer(new ForegroundOccluderScaleRandomizer());
            scenario.AddRandomizer(new ForegroundScaleRandomizer());
            scenario.AddRandomizer(new TextureRandomizer());
            scenario.AddRandomizer(new HueOffsetRandomizer());
            scenario.AddRandomizer(new RotationRandomizer());
            scenario.AddRandomizer(new UnifiedRotationRandomizer());
            scenario.AddRandomizer(new LightRandomizer());
            scenario.AddRandomizer(new CameraRandomizer());
            scenario.AddRandomizer(new ForegroundObjectMetricReporter());
            scenario.AddRandomizer(new LightingInfoMetricReporter());
            scenario.AddRandomizer(new CameraPostProcessingMetricReporter());

            Selection.activeGameObject = scenarioObj;
        }
    }
}
