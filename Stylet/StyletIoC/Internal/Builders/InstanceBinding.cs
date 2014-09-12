﻿using StyletIoC.Internal.Creators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletIoC.Internal.Builders
{
    internal class InstanceBinding : BuilderBindingBase
    {
        private readonly object instance;

        public InstanceBinding(Type serviceType, object instance)
            : base(serviceType)
        {
            this.EnsureType(instance.GetType());
            this.instance = instance;
        }

        public override void Build(Container container)
        {
            var creator = new InstanceCreator(this.instance);
            var registration = this.CreateRegistration(container, creator);

            container.AddRegistration(new TypeKey(this.serviceType, this.Key), registration);
        }
    }
}
