using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SOLID.SingleBehaviour
{
    public class timer : MonoBehaviour
    {
        [SerializeField] private float duration = 1f;
        [SerializeField] private UnityEvent onTimerEnd = new UnityEvent();

        private void Start()
        {
            StartCoroutine(StartTimer());
        }

        private IEnumerator StartTimer()
        {

            yield return new WaitForSeconds(duration);

            onTimerEnd?.Invoke();

        }

    }
}
