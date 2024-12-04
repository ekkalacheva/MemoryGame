using System;
using System.Collections;
using UnityEngine;

namespace MemoryGame.Utils
{
    internal static class CoroutineExtensions
    {
        public static void YieldAction(this MonoBehaviour obj, Action targetAction, float delay)
        {
            obj.StartCoroutine(YieldActionEnumerator(targetAction, delay));
        }

        public static Coroutine YieldActionCoroutine(this MonoBehaviour obj, Action targetAction, float delay)
        {
            return obj.StartCoroutine(YieldActionEnumerator(targetAction, delay));
        }

        public static IEnumerator YieldActionEnumerator(Action targetAction, float delay)
        {
            yield return new WaitForSeconds(delay);
            targetAction?.Invoke();
        }
    }
}
