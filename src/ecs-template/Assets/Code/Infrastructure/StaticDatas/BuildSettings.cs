using UnityEngine;

namespace Code.Infrastructure.StaticDatas
{
    [CreateAssetMenu(menuName = "BuildSettings", fileName = "BuildSettings", order = 0)]
    public class BuildSettings : ScriptableObject
    {
        public bool MakeBuild = false;
    }
}