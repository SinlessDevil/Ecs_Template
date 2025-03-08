using Code.Meta.UI.GoldHolder.Service;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;
using UnityEngine.UI;

namespace Code.Meta.UI.GoldHolder.Behavior
{
    public class GoldHolder : MonoBehaviour
    {
        [FormerlySerializedAs("goldText")] [SerializeField] private Text _goldText;
        [FormerlySerializedAs("BoostText")] [SerializeField] private Text _BoostText;
        
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
                    _BoostText.gameObject.SetActive(true);
                    _BoostText.text = boost.ToString("+0%");
                    break;
                default:
                    _BoostText.gameObject.SetActive(false);
                    break;
            }
        }

        private void OnDestroy()
        {
            _storage.GoldChangedEvent -= OnGoldChanged;
            _storage.GoldBoostChangedEvent -= OnUpdateBoost;
        }
        
        private void OnGoldChanged() =>
            _goldText.text = _storage.CurrentGold.ToString("0");
    }
}