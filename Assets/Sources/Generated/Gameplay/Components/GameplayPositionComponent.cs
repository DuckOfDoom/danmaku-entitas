//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public DuckOfDoom.Danmaku.PositionComponent position { get { return (DuckOfDoom.Danmaku.PositionComponent)GetComponent(GameplayComponentsLookup.Position); } }
    public bool hasPosition { get { return HasComponent(GameplayComponentsLookup.Position); } }

    public void AddPosition(UnityEngine.Vector2 newValue) {
        var index = GameplayComponentsLookup.Position;
        var component = CreateComponent<DuckOfDoom.Danmaku.PositionComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePosition(UnityEngine.Vector2 newValue) {
        var index = GameplayComponentsLookup.Position;
        var component = CreateComponent<DuckOfDoom.Danmaku.PositionComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePosition() {
        RemoveComponent(GameplayComponentsLookup.Position);
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

    static Entitas.IMatcher<GameplayEntity> _matcherPosition;

    public static Entitas.IMatcher<GameplayEntity> Position {
        get {
            if (_matcherPosition == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.Position);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherPosition = matcher;
            }

            return _matcherPosition;
        }
    }
}
