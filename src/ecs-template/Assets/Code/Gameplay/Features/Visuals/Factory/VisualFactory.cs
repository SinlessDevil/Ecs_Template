using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Visuals.Factory
{
    public class VisualFactory : IVisualFactory
    {
        private const string VisualPrefabPath = "Prefabs/Visuals/Visual";
        
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public VisualFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        
        public Visual CreateVisual(Vector3 at, Transform parent)
        {
            var visual = _instantiator.InstantiatePrefabForComponent<Visual>(
                _assetProvider.LoadAsset<Visual>(VisualPrefabPath));

            visual.transform.SetParent(parent);
            visual.transform.localPosition = at;

            return visual;
        }
    }
}