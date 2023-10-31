using Basic2DGame.GameFiles.Entity_Component_System.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles.Entity_Component_System.Systems;

public static class HealthSystem
{
    public static void Update()
    {
        // Get all the entities that have a health component
        var entities = ComponentManager.ComponentManager.GetAllEntitiesWithComponent<HealthComponent>();
        // Loop through all the entities
        foreach (var entity in entities)
        {
            // Get the health component
            var healthComponent = ComponentManager.ComponentManager.GetComponent<HealthComponent>(entity);
            // If the health is less than or equal to 0
            if (healthComponent.Health <= 0)
            {
                // Set the health to 0
                healthComponent.ChangeValue("Health", 0);
                // Set the entity to dead
                healthComponent.ChangeValue("IsDead", true);
            }
            // If the health is greater than the max health
            if (healthComponent.Health > healthComponent.MaxHealth)
            {
                // Set the health to the max health
                healthComponent.ChangeValue("Health", healthComponent.MaxHealth);
            }
            healthComponent.Update();
        }
    }
}
