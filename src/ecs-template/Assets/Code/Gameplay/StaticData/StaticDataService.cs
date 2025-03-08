using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.Features.Hero.Configs;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using Code.Meta.Features.AfkGain.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyTypeId, EnemyConfig> _enemyById;
        private Dictionary<WindowId, GameObject> _windowPrefabsById;
        
        private HeroConfig _heroConfig;
        private EnemySpawnConfig _enemySpawnConfig;
        private AfkGainConfig _afkGainConfig;

        public void LoadAll()
        {
            LoadEnemies();
            LoadHeroConfig();
            LoadWindows();
            LoadEnemySpawnConfig();
            LoadAfkGainConfig();
        }
        
        public AfkGainConfig AfkGainConfig => _afkGainConfig;
        
        public EnemySpawnConfig EnemySpawnConfig => _enemySpawnConfig;
        
        public HeroConfig HeroConfig => _heroConfig;

        public EnemyWave GetCurrentWave(int level)
        {
            for (int i = _enemySpawnConfig.Waves.Count - 1; i >= 0; i--)
            {
                if (level >= _enemySpawnConfig.Waves[i].LevelRequirement)
                    return _enemySpawnConfig.Waves[i];
            }
            return null;
        }
        
        public EnemyConfig GetEnemyConfig(EnemyTypeId enemyTypeId)
        {
            if(_enemyById.TryGetValue(enemyTypeId, out EnemyConfig config)) 
                return config;

            throw new Exception($"Enemy config for {enemyTypeId} not found");
        }

        public EnemyLevel GetEnemyLevel(EnemyTypeId enemyTypeId, int level)
        {
            EnemyConfig config = GetEnemyConfig(enemyTypeId);
            
            if (level > config.Levels.Count)
                level = config.Levels.Count;
            
            EnemyLevel closestLevel = null;
            foreach (var enemyLevel in config.Levels)
            {
                if (config.Levels.IndexOf(enemyLevel) <= level) 
                {
                    closestLevel = enemyLevel;
                }
                else
                {
                    break;
                }
            }
            return closestLevel;
        }
        
        public GameObject GetWindowPrefab(WindowId windowId)
        {
           return _windowPrefabsById.TryGetValue(windowId, out GameObject windowPrefab)
                ? windowPrefab
                : throw new Exception($"Prefab config for window {windowId} was not found");
        }
        
        private void LoadEnemies()
        {
            _enemyById = Resources
                .LoadAll<EnemyConfig>("Configs/Enemies")
                .ToDictionary(x => x.EnemyTypeId, x => x);
        }
        
        private void LoadHeroConfig()
        {
            _heroConfig = Resources.Load<HeroConfig>("Configs/Heroes/HeroConfig");
        }
        
        private void LoadWindows()
        {
            _windowPrefabsById = Resources
                .Load<WindowsConfig>("Configs/Windows/WindowConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }

        private void LoadEnemySpawnConfig()
        {
            _enemySpawnConfig = Resources.Load<EnemySpawnConfig>("Configs/EnemySpawn/EnemySpawnConfig");
        }
        
        private void LoadAfkGainConfig()
        {
            _afkGainConfig = Resources.Load<AfkGainConfig>("Configs/AfkGain/AfkGainConfig");
        }
    }
}
