using System.Collections.Generic;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.Features.Hero.Configs;
using Code.Gameplay.Windows;
using Code.Infrastructure.StaticDatas;
using Code.Meta.Features.AfkGain.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        public void LoadAll();

        public AfkGainConfig AfkGainConfig { get; }
        public EnemySpawnConfig EnemySpawnConfig { get; }
        public HeroConfig HeroConfig { get; }
        public GameConfig GameConfig { get; }

        public EnemyWave GetCurrentWave(int level);

        public EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId);
        public EnemyLevel GetEnemyLevel(EnemyTypeId enemyTypeId, int level);
        
        public GameObject GetWindowPrefab(WindowId windowId);
    }
}