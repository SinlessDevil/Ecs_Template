using FluentAssertions;
using NUnit.Framework;
using UnityEngine;
using BuildSettings = Code.Infrastructure.StaticDatas.BuildSettings;

namespace Tests.EditMode
{
    public class LevelDataValidationTests
    {
        [Test]
        public void BuildCompiling()
        {
            BuildSettings().MakeBuild.Should().BeTrue();
        }
        
        private static BuildSettings BuildSettings() => Resources.Load<BuildSettings>("StaticData/BuildSettings");
    }
}