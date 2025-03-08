using Code.Progress.Provider;
using UnityEngine;
using Zenject;

namespace Services.SFX
{
    public class MusicService : MonoBehaviour, IMusicService
    {
        [SerializeField] private AudioSource _audioSource;
        private bool _isMusic => _progressService.ProgressData.Music;
        
        private IProgressProvider _progressService;

        [Inject]
        public void Constructor(IProgressProvider progressService)
        {
            _progressService = progressService;
        }
        
        public void Update()
        {
            if (!_isMusic && _audioSource.isPlaying)
                _audioSource.Stop();
            
            if(_isMusic && !_audioSource.isPlaying)
                _audioSource.Play();
        }
    }

    public interface IMusicService
    {
    }
}