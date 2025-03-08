using Code.Gameplay.Features.Effects.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damageEffects;
        private readonly IGroup<GameEntity> _invulnerabilityEffects;
        
        public ProcessDamageEffectSystem(GameContext game)
        {
            _damageEffects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DamageEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId));

            _invulnerabilityEffects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EffectValue,
                GameMatcher.TargetId));
        }
        
        public void Execute()
        {
            foreach (GameEntity damageEffect in _damageEffects)
            {
                GameEntity target = damageEffect.Target();

                damageEffect.isProcessed = true;
                
                if(target.isDead)
                    continue;
                
                if(!target.hasCurrentHp)
                    return;
                
                target.ReplaceCurrentHp(target.CurrentHp - damageEffect.EffectValue);
                
                if(target.hasDamageTakenAnimator)
                    target.DamageTakenAnimator.PlayDamageTaken();
            }
        }
    }
}