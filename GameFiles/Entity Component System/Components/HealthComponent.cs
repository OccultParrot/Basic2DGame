using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles.Entity_Component_System.Components;

public struct HealthComponent : IComponent
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public bool IsDead { get; private set; }
    public HealthComponent(int health)
    {
        Health = health;
        MaxHealth = health;
        IsDead = false;
    }

    public readonly void Update()
    {
    }

    /// <summary>
    /// Changes the value of a variable.
    /// </summary>
    /// <param name="valueName">Health, MaxHealth, IsDead</param>
    /// <param name="value">The value that you want to change it to.</param>
    public void ChangeValue(string valueName, object value)
    {
        switch (valueName)
        {
            case "Health":
                Health = (int)value;
                break;
            case "MaxHealth":
                MaxHealth = (int)value;
                break;
            case "IsDead":
                IsDead = (bool)value;
                break;
        }
    }
}
