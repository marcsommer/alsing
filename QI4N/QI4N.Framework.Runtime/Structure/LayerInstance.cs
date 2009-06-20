namespace QI4N.Framework.Runtime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LayerInstance
    {
        private ApplicationInstance applicationInstance;

        private readonly LayerModel model;

        private readonly IList<ModuleInstance> moduleInstances;

        private UsedLayersInstance usedLayersInstance;

        public LayerInstance(LayerModel model, ApplicationInstance applicationInstance, IList<ModuleInstance> moduleInstances, UsedLayersInstance usedLayersInstance)
        {
            this.model = model;
            this.applicationInstance = applicationInstance;
            this.moduleInstances = moduleInstances;
            this.usedLayersInstance = usedLayersInstance;
            //   this.moduleActivator = new Activator();
        }

        public LayerModel Model
        {
            get
            {
                return this.model;
            }
        }

        public void VisitModules(ModuleVisitor visitor, Visibility visibility)
        {
            
        }

        public ModuleInstance FindModule(string moduleName)
        {
            var moduleInstance = moduleInstances
                                    .Where(l => l.Model.Name == moduleName)
                                    .FirstOrDefault();


            return moduleInstance;
        }
    }
}