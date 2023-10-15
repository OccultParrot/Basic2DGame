using Basic2DGame.GameFiles.Entity_Component_System.Components;
using System;
using System.Collections.Generic;

namespace Basic2DGame.GameFiles.Entity_Component_System.ComponentManager;

public class ComponentManager
{
    private readonly Dictionary<Type, Dictionary<uint, IComponent>> _components = new();
    private readonly List<Type> _componentTypes = new()
    {
        typeof(HealthComponent), typeof(PositionComponent), typeof(BoundsComponent)
    };

    public ComponentManager()
    {
        for (int i = 0; i < _componentTypes.Count; i++)
            _components.Add(_componentTypes[i], new());
    }

    public void AddComponent(uint EntityID, IComponent componentType)
    {
        switch (componentType)
        {
            // If componentType is of type HealthComponent, add it to the dictionary.
            case HealthComponent healthComponent:
                if (!_components[typeof(HealthComponent)].ContainsKey(EntityID))
                    _components[typeof(HealthComponent)].Add(EntityID, healthComponent);
                else
                    _components[typeof(HealthComponent)][EntityID] = healthComponent;
                break;
            // If componentType is of type PositionComponent, add it to the dictionary.
            case PositionComponent positionComponent:
                if (!_components[typeof(PositionComponent)].ContainsKey(EntityID))
                    _components[typeof(PositionComponent)].Add(EntityID, positionComponent);
                else
                    _components[typeof(PositionComponent)][EntityID] = positionComponent;
                break;
            // If componentType if of type BoundsComponent, add it to the dictionary.
            case BoundsComponent boundsComponent:
                if (!_components[typeof(BoundsComponent)].ContainsKey(EntityID))
                    _components[typeof(BoundsComponent)].Add(EntityID, boundsComponent);
                else
                    _components[typeof(BoundsComponent)][EntityID] = boundsComponent;
                break;
        }
    }
    public void RemoveComponent(uint EntityID, IComponent componentType)
    {
        switch (componentType)
        {
            // If componentType is of type HealthComponent, remove it from the dictionary.
            case HealthComponent:
                if (_components[typeof(HealthComponent)].ContainsKey(EntityID))
                    _components[typeof(HealthComponent)].Remove(EntityID);
                break;
            // If componentType is of type PositionComponent, remove it from the dictionary.
            case PositionComponent:
                if (_components[typeof(PositionComponent)].ContainsKey(EntityID))
                    _components[typeof(PositionComponent)].Remove(EntityID);
                break;
            // If componentType is of type BoundsComponent, remove it from the dictionary.
            case BoundsComponent:
                if (_components[typeof(PositionComponent)].ContainsKey(EntityID))
                    _components[typeof(PositionComponent)].Remove(EntityID);
                break;
        }
    }
    public IComponent GetComponent(uint EntityID, IComponent componentType)
    {
        switch (componentType)
        {
            // If componentType is of type HealthComponent, return the value of the entity's component if any.
            case HealthComponent:
                if (_components[typeof(HealthComponent)].ContainsKey(EntityID))
                    return _components[typeof(HealthComponent)][EntityID];
                else
                    return null;
            // If componentType is of type PositionComponent, return the value of the entity's component if any.
            case PositionComponent:
                if (_components[typeof(PositionComponent)].ContainsKey(EntityID))
                    return _components[typeof(PositionComponent)][EntityID];
                else
                    return null;
            // If componentType is of type BoundsComponent, return the value of the entity's component if any.
            case BoundsComponent:
                if (_components[typeof(BoundsComponent)].ContainsKey(EntityID))
                    return _components[typeof(BoundsComponent)][EntityID];
                else
                    return null;
            // Return null if all are not true.
            default:
                return null;
        }
    }
}