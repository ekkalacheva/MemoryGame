using System;
using System.Collections;
using UnityEngine;

namespace MemoryGame.Utils
{
    internal class CoroutineHandler : MonoBehaviour, ICoroutineHandler
    {

        public Coroutine GetCoroutine(IEnumerator routine)
        {
            return base.StartCoroutine(routine);
        }

        public new void StartCoroutine(IEnumerator routine)
        {
            base.StartCoroutine(routine);
        }

        public new void StopCoroutine(IEnumerator routine)
        {

            base.StopCoroutine(routine);
        }

        public new void StopCoroutine(Coroutine routine)
        {
            base.StopCoroutine(routine);
        }

        public Coroutine DelayAction(Action action, float delay)
        {
            return this.YieldActionCoroutine(action, delay);
        }
    }
}
