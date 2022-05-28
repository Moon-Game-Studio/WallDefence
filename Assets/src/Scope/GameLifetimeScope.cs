using VContainer;
using VContainer.Unity;

namespace src.Scope
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseEntryPoints(Lifetime.Singleton, RegisterPresenters);
            builder.UseComponents(RegisterMonos);
            RegisterServices(builder);
            RegisterMessagePipes(builder);
        }

        private void RegisterMessagePipes(IContainerBuilder builder) { }

        private void RegisterServices(IContainerBuilder builder) { }

        private void RegisterMonos(ComponentsBuilder obj) { }

        private void RegisterPresenters(EntryPointsBuilder obj) { }
    }
}