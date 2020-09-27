using UnityEngine;

namespace h8s
{
    public class BlackboardController : MonoBehaviour
    {
        public static BlackboardController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); }
            else { Instance = this; }
        }
    }
}
