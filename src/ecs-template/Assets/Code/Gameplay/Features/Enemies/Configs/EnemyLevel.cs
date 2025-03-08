using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;

namespace Code.Gameplay.Features.Enemies.Configs
{
    [Serializable]
    public class EnemyLevel
    {
        public float Hp = 3;
        public float Speed = 1;
        public float RadiusToCollectTargets = 0.3f;
        public float CollectTargetsInterval = 0.5f;
        
        public List<EffectSetup> EffectSetups;
        
        public float RadiusToFindEnemy = 3;
        public float CreateEffectInterval = 3;
    }
}