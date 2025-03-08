using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Configs
{
    [CreateAssetMenu(menuName = "ECS/EnemySpawn", fileName = "EnemySpawnConfig")]
    public class EnemySpawnConfig : ScriptableObject
    {
        public List<EnemyWave> Waves = new()
        {
            new()
            {
                LevelRequirement = 1,
                SpawnInterval = 3f,
                Enemies = new List<EnemySpawnData>
                {
                    new() { EnemyType = EnemyTypeId.Goblin, MinCount = 2, MaxCount = 4 },
                }
            },
        };
    }
            
    [Serializable]
    public class EnemyWave
    {
        public int LevelRequirement;
        public float SpawnInterval;
        public List<EnemySpawnData> Enemies;
    }
        
    [Serializable]
    public class EnemySpawnData
    {
        public EnemyTypeId EnemyType;
        public int MinCount;
        public int MaxCount;
    }
}