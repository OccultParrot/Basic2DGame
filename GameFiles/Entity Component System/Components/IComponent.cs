using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic2DGame.GameFiles.Entity_Component_System.Components
{
    public interface IComponent
    {
        /// <summary>
        /// Refreshes data the systems need to know about.
        /// </summary>
        internal void Update();

        public void ChangeValue(string valueName, object value);
    }
}
