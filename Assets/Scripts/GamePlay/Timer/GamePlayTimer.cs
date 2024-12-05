using System;
using UnityEngine;
using Zenject;

namespace MemoryGame.GamePlay
{
    internal class GamePlayTimer: IGamePlayTimer, ITickable, IInitializable, IDisposable
    {
        private readonly SignalBus _signals;

        private float _elapsedSeconds;
        private bool _isActive;

        public float ElapsedSeconds
        {
            get { return _elapsedSeconds; }
            private set
            {
                _elapsedSeconds = value;
                TimeChanged?.Invoke();
            }
        }

        public event Action TimeChanged;

        public GamePlayTimer(SignalBus signals)
        {
            _signals = signals;
        }

        public void Tick()
        {
            if (!_isActive)
            {
                return;
            }

            ElapsedSeconds += Time.deltaTime;
        }

        public void Initialize()
        {
            _signals.Subscribe<GamePlaySignals.GameStarted>(StartTimer);
            _signals.Subscribe<GamePlaySignals.GameCompleted>(StopTimer);
        }

        public void Dispose()
        {
            _signals.Unsubscribe<GamePlaySignals.GameStarted>(StartTimer);
            _signals.Unsubscribe<GamePlaySignals.GameCompleted>(StopTimer);
        }

        private void StartTimer()
        {
            _isActive = true;
        }

        private void StopTimer()
        {
            _isActive = false;
        }
    }
}
