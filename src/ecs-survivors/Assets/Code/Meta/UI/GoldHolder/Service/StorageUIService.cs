using System;

namespace Code.Meta.UI.GoldHolder.Service
{
    public class StorageUIService : IStorageUIService
    {
        private float _currentGold;
        private float _goldGainBoost;

        public event Action GoldChangedEvent;
        public event Action GoldBoostChangedEvent;
        
        public float CurrentGold => _currentGold;
        
        public float GoldGainBoost => _goldGainBoost;

        public void UpdateGoldGainBoost(float boost)
        {
            _goldGainBoost = boost;
            GoldBoostChangedEvent?.Invoke();
        }
        
        public void UpdateCurrentGold(float gold)
        {
            if (Math.Abs(gold - _currentGold) > float.Epsilon)
            {
                _currentGold = gold;
                GoldChangedEvent?.Invoke();
            }
        }

        public void Cleanup()
        {
            _currentGold = 0f;
            _goldGainBoost = 0f;
            
            GoldChangedEvent = null;
            GoldBoostChangedEvent = null;
        }
    }
}