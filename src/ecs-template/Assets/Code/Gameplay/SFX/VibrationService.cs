using Code.Progress.Provider;
using Zenject;

namespace Services.SFX
{
    public class VibrationService : IVibrationService
    {
        private bool _isVibration => _progressService.ProgressData.Vibration;
        private IProgressProvider _progressService;

        [Inject]
        public void Constructor(IProgressProvider progressService)
        {
            _progressService = progressService;
        }

        public void Light()
        {
            if (_isVibration)
                Vibration.LightImpact();
        }

        public void Medium()
        {
            if (_isVibration)
                Vibration.MediumImpact();
        }

        public void Heavy()
        {
            if (_isVibration)
                Vibration.HeavyImpact();
        }
    }
}

public interface IVibrationService
{
    void Light();
    void Medium();
    void Heavy();
}