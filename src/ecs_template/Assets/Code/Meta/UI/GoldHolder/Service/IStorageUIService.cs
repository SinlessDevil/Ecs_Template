using System;

namespace Code.Meta.UI.GoldHolder.Service
{
    public interface IStorageUIService
    {
        event Action GoldChangedEvent;
        
        float CurrentGold { get; }
        float GoldGainBoost { get; }
        
        void UpdateCurrentGold(float gold);
        void UpdateGoldGainBoost(float boost);
        
        void Cleanup();
        event Action GoldBoostChangedEvent;
    }
}