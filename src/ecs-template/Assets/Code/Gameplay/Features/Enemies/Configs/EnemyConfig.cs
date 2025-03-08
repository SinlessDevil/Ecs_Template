using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Configs
{
    [CreateAssetMenu(menuName = "ECS/Enemies", fileName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        public List<EnemyLevel> Levels;
    }
}