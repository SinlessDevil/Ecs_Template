using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public EnemyFactory(
            IIdentifierService identifierService, 
            IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at, int level = 1)
        {
            return typeId switch
            {
                EnemyTypeId.Goblin => CreateGoblin(typeId, at, level),
                _ => throw new Exception($"Enemy with type id {typeId} does not exist")
            };
        }

        private GameEntity CreateGoblin(EnemyTypeId typeId, Vector3 at, int level)
        {
            EnemyLevel enemyLevel = _staticDataService.GetEnemyLevel(typeId, level);
            
            string viewPath = "Gameplay/Enemies/Goblins/Torch/goblin_torch_blue";
            
            return CreateEnemyEntity(typeId, at, viewPath, enemyLevel)
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(enemyLevel.RadiusToCollectTargets)
                .AddCollectTargetsInterval(enemyLevel.CollectTargetsInterval)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask());
        }
        
        
        private GameEntity CreateEnemyEntity(EnemyTypeId typeId, Vector3 at, string viewPath, EnemyLevel enemyLevel)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddEnemyTypeID(typeId)
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddViewPath(viewPath)
                .AddSpeed(enemyLevel.Speed)
                .AddCurrentHp(enemyLevel.Hp)
                .AddMaxHp(enemyLevel.Hp)
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true);
        }
    }
}