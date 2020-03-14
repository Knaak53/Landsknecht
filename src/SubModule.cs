namespace Landsknecht
{
    /**
    Loading and unloading the mod itself?

    Mandatory for correct mod loading by the engine
    */
    public class SubModule: TaleWorlds.MountAndBlade.MBSubModuleBase
    {
        private static SubModule _instance;
        private bool _initialized;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            SubModule._instance = this;
        }

        protected override void OnSubModuleUnloaded()
        {
            SubModule._instance = (SubModule)null;
            base.OnSubModuleUnloaded();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            if (this._initialized)
                return;
            this._initialized = true;
        }

        protected override void OnApplicationTick(float dt)
        {
            // ModuleLogger.Writer.WriteLine("EnhancedBattleTestSubModule::OnApplicationTick {0}", dt);
            base.OnApplicationTick(dt);
        }
    }
}
