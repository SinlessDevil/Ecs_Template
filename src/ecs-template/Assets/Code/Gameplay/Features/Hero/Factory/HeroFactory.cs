using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {   
        private readonly IIdentifierService _identifierService;
        private readonly IStaticDataService _staticDataService;

        public HeroFactory(
            IIdentifierService identifierService, 
            IStaticDataService staticDataService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }
        
        public GameEntity CreateHero(Vector3 at)
        {
            HeroConfig heroConfig = _staticDataService.HeroConfig;
            
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddDirection(Vector2.zero)
                .AddSpeed(heroConfig.Speed)
                .AddCurrentHp(heroConfig.Hp)
                .AddMaxHp(heroConfig.Hp)
                .AddViewPath("Gameplay/Hero/hero")
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true);
        }
    }
}