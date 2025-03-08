using Code.Infrastructure.Systems;
using Code.Meta.UI.GoldHolder.Systems;

namespace Code.Meta
{
    public class HomeUIFeature : Feature
    {
        public HomeUIFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<RefreshGoldGainBoostSystem>());
            Add(systemFactory.Create<RefreshGoldSystem>());
        }
    }
}