using Code.Common.Destruct;
using Code.Gameplay.Features.EffectApplication;
using Code.Gameplay.Features.Effects.Systems;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.LifeTime;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.GameOver.Systems;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory system)
        {
            Add(system.Create<InputFeature>());
            Add(system.Create<BindViewFeature>());
            
            Add(system.Create<HeroFeature>());
            Add(system.Create<EnemyFeature>());
            Add(system.Create<DeathFeature>());
            
            Add(system.Create<MovementFeature>());
            
            Add(system.Create<CollectTargetFeature>());
            Add(system.Create<EffectApplicationFeature>());
            
            Add(system.Create<EffectFeature>());
            
            Add(system.Create<GameOverOnHeroDeathSystem>());
            
            Add(system.Create<ProcessDestructedFeature>());
        }
    }
}