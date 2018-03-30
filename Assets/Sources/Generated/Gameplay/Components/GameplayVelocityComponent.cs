//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public DuckOfDoom.Danmaku.VelocityComponent velocity { get { return (DuckOfDoom.Danmaku.VelocityComponent)GetComponent(GameplayComponentsLookup.Velocity); } }
    public bool hasVelocity { get { return HasComponent(GameplayComponentsLookup.Velocity); } }

    public void AddVelocity(UnityEngine.Vector2 newLinear, float newAngular) {
        var index = GameplayComponentsLookup.Velocity;
        var component = CreateComponent<DuckOfDoom.Danmaku.VelocityComponent>(index);
        component.Linear = newLinear;
        component.Angular = newAngular;
        AddComponent(index, component);
    }

    public void ReplaceVelocity(UnityEngine.Vector2 newLinear, float newAngular) {
        var index = GameplayComponentsLookup.Velocity;
        var component = CreateComponent<DuckOfDoom.Danmaku.VelocityComponent>(index);
        component.Linear = newLinear;
        component.Angular = newAngular;
        ReplaceComponent(index, component);
    }

    public void RemoveVelocity() {
        RemoveComponent(GameplayComponentsLookup.Velocity);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameplayMatcher {

    static Entitas.IMatcher<GameplayEntity> _matcherVelocity;

    public static Entitas.IMatcher<GameplayEntity> Velocity {
        get {
            if (_matcherVelocity == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.Velocity);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherVelocity = matcher;
            }

            return _matcherVelocity;
        }
    }
}
