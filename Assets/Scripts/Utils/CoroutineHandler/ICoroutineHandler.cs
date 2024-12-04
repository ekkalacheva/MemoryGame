using System;
using System.Collections;
using UnityEngine;

namespace MemoryGame.Utils
{
    internal interface ICoroutineHandler
    {
        void StartCoroutine(IEnumerator routine);

        void StopCoroutine(IEnumerator routine);

        void StopCoroutine(Coroutine routine);

        Coroutine GetCoroutine(IEnumerator routine);

        void StopAllCoroutines();

        Coroutine DelayAction(Action action, float delay);
    }
}
