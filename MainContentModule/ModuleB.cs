using MainContentModule.Views;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;

namespace MainContentModule
{
    [ModuleExport(typeof(ModuleB), InitializationMode = InitializationMode.WhenAvailable)]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ModuleB : IModule
    {
        private readonly IRegionManager regionManager;
        [ImportingConstructor]
        public ModuleB(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("MainContent", typeof(ViewB));
        }
    }
}
