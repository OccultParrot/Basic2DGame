using Basic2DGame.GameFiles.Entity_Component_System.Components;
using System;
using System.Collections.Generic;

namespace Basic2DGame.GameFiles.Entity_Component_System.ComponentManager;

public static class ComponentManager
{
    private static readonly Dictionary<Type, Dictionary<uint, IComponent>> _components = new();

    public static void AddComponent(uint EntityID, IComponent component)
    {
        if (!_components.ContainsKey(component.GetType()))
            _components.Add(component.GetType(), new());

        if (_components[component.GetType()].ContainsKey(EntityID))
            _components[component.GetType()][EntityID] = component;

        else
            _components[component.GetType()].Add(EntityID, component);
    }
    public static void RemoveComponent<T>(uint EntityID) where T : IComponent
    {
        if (!_components.ContainsKey(typeof(T)))
            return;
        if (_components[typeof(T)].ContainsKey(EntityID))
            _components[typeof(T)].Remove(EntityID);
    }

    /// <summary>
    /// Returns the component of the specified type attached to the entity.
    /// </summary>
    /// <typeparam name="T">The type of the component.</typeparam>
    /// <param name="EntityID">The ID of the Entity. Entities are constructed with a unique ID</param>
    /// <returns></returns>
    public static T GetComponent<T>(uint EntityID) where T : IComponent
    {
        if (!_components.ContainsKey(typeof(T)))
            return default;
        return (T)_components[typeof(T)][EntityID];
    }

    public static uint[] GetAllEntitiesWithComponent<T>() where T : IComponent
    {
        var entities = new List<uint>();
        foreach (var component in _components[typeof(T)])
        {
            entities.Add(component.Key);
        }
        return entities.ToArray();
    }
}