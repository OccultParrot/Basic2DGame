using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles.Entity_Component_System.Components;
internal class SelectableComponent : IComponent
{
    /// <summary>
    /// Tells if the entity is selected.
    /// </summary>
    public bool IsSelected { get; private set; }

    /// <summary>
    /// This event is raised when the entity is selected.
    /// </summary>
    public event EventHandler OnSelected;
    public SelectableComponent() { }

    public void Update()
    {
        if (IsSelected)
            // Raise the event
            OnSelected?.Invoke(this, EventArgs.Empty);
    }
    public void ChangeValue(string valueName, object value)
    {
        switch (valueName)
        {
            case "IsSelected":
                IsSelected = (bool)value;
                break;
        }
    }
}