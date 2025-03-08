using UnityEngine;

namespace Code.Gameplay.Features.Visuals.Factory
{
    public interface IVisualFactory
    {
        Visual CreateVisual(Vector3 at, Transform parent);
    }
}