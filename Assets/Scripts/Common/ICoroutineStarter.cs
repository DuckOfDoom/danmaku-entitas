using System;
using System.Collections;
using UnityEngine;

namespace DuckOfDoom.Danmaku
{
    public interface ICoroutineStarter 
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine coroutine);
    }
    
    public class CoroutineStarter : MonoBehaviour, ICoroutineStarter
    {
    }
}