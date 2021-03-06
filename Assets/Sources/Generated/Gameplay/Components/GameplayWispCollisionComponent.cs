//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameplayEntity {

    public DuckOfDoom.Danmaku.WispCollision wispCollision { get { return (DuckOfDoom.Danmaku.WispCollision)GetComponent(GameplayComponentsLookup.WispCollision); } }
    public bool hasWispCollision { get { return HasComponent(GameplayComponentsLookup.WispCollision); } }

    public void AddWispCollision(GameplayEntity newCollidedWith) {
        var index = GameplayComponentsLookup.WispCollision;
        var component = CreateComponent<DuckOfDoom.Danmaku.WispCollision>(index);
        component.CollidedWith = newCollidedWith;
        AddComponent(index, component);
    }

    public void ReplaceWispCollision(GameplayEntity newCollidedWith) {
        var index = GameplayComponentsLookup.WispCollision;
        var component = CreateComponent<DuckOfDoom.Danmaku.WispCollision>(index);
        component.CollidedWith = newCollidedWith;
        ReplaceComponent(index, component);
    }

    public void RemoveWispCollision() {
        RemoveComponent(GameplayComponentsLookup.WispCollision);
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

    static Entitas.IMatcher<GameplayEntity> _matcherWispCollision;

    public static Entitas.IMatcher<GameplayEntity> WispCollision {
        get {
            if (_matcherWispCollision == null) {
                var matcher = (Entitas.Matcher<GameplayEntity>)Entitas.Matcher<GameplayEntity>.AllOf(GameplayComponentsLookup.WispCollision);
                matcher.componentNames = GameplayComponentsLookup.componentNames;
                _matcherWispCollision = matcher;
            }

            return _matcherWispCollision;
        }
    }
}
