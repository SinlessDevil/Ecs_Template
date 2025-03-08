using Code.Meta.UI.GoldHolder.Service;
using UnityEngine;
using Zenject;
using TMPro;

namespace Code.Meta.UI.GoldHolder.Behavior
{
    public class GoldHolder : MonoBehaviour
    {
        public TextMeshProUGUI goldText;
        public TextMeshProUGUI BoostText;
        
        private IStorageUIService _storage;

        [Inject]
        private void Construct(IStorageUIService storageUIService)
        {
            _storage = storageUIService;
        }
        
        private void Start()
        {
            _storage.GoldChangedEvent += OnGoldChanged;
            _storage.GoldBoostChangedEvent += OnUpdateBoost;
            
            OnGoldChanged();
        }

        private void OnUpdateBoost()
        {
            float boost = _storage.GoldGainBoost;

            switch (boost)
            {
                case > 0:
                    BoostText.gameObject.SetActive(true);
                    BoostText.text = boost.ToString("+0%");
                    break;
                default:
                    BoostText.gameObject.SetActive(false);
                    break;
            }
        }

        private void OnDestroy()
        {
            _storage.GoldChangedEvent -= OnGoldChanged;
            _storage.GoldBoostChangedEvent -= OnUpdateBoost;
        }
        
        private void OnGoldChanged() =>
            goldText.text = _storage.CurrentGold.ToString("0");
    }
}