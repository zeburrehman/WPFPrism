using LeftMenuModule.Views;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;

namespace LeftMenuModule
{
    [ModuleExport(typeof(ModuleA), InitializationMode = InitializationMode.WhenAvailable)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ModuleA : IModule
    {
        private readonly IRegionManager regionManager;
        [ImportingConstructor]
        public ModuleA(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("LeftMenu", typeof(ViewA));
        }
    }
}
