using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.Items
{
    public abstract class ActiveObject
    {
        public virtual int ID { get; }
        public virtual string Name { get; }
        public virtual int InstanceNumber { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        public event ActivatedObjectHandler OnActivation;
        public event ActivatedObjectHandler WhileActive;
        public event ActivatedObjectHandler OnDeactivation;

        public virtual void Activate()
        {
            IsActive = true;
            OnActivation(this, new EventArgs());
        }

        public virtual void Deactivate()
        {
            IsActive = false;
            OnDeactivation(this, new EventArgs());
        }

        public delegate void ActivatedObjectHandler(ActiveObject sender, EventArgs e);
    }
}
