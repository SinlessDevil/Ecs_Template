//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherTick;

    public static Entitas.IMatcher<MetaEntity> Tick {
        get {
            if (_matcherTick == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.Tick);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherTick = matcher;
            }

            return _matcherTick;
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
public partial class MetaEntity {

    public Code.Meta.Features.Simulation.Tick tick { get { return (Code.Meta.Features.Simulation.Tick)GetComponent(MetaComponentsLookup.Tick); } }
    public float Tick { get { return tick.Value; } }
    public bool hasTick { get { return HasComponent(MetaComponentsLookup.Tick); } }

    public MetaEntity AddTick(float newValue) {
        var index = MetaComponentsLookup.Tick;
        var component = (Code.Meta.Features.Simulation.Tick)CreateComponent(index, typeof(Code.Meta.Features.Simulation.Tick));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public MetaEntity ReplaceTick(float newValue) {
        var index = MetaComponentsLookup.Tick;
        var component = (Code.Meta.Features.Simulation.Tick)CreateComponent(index, typeof(Code.Meta.Features.Simulation.Tick));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public MetaEntity RemoveTick() {
        RemoveComponent(MetaComponentsLookup.Tick);
        return this;
    }
}
