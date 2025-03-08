//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherScatteringRuneStoneAbility;

    public static Entitas.IMatcher<GameEntity> ScatteringRuneStoneAbility {
        get {
            if (_matcherScatteringRuneStoneAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ScatteringRuneStoneAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherScatteringRuneStoneAbility = matcher;
            }

            return _matcherScatteringRuneStoneAbility;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.Gameplay.Features.Abilities.ScatteringRuneStoneAbility scatteringRuneStoneAbilityComponent = new Code.Gameplay.Features.Abilities.ScatteringRuneStoneAbility();

    public bool isScatteringRuneStoneAbility {
        get { return HasComponent(GameComponentsLookup.ScatteringRuneStoneAbility); }
        set {
            if (value != isScatteringRuneStoneAbility) {
                var index = GameComponentsLookup.ScatteringRuneStoneAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : scatteringRuneStoneAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
