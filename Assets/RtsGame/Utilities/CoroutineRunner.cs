using UnityEngine;

namespace RtsGame.Utilities
{
    public class CoroutineRunner : MonoBehaviour
    {
        private static CoroutineRunner instance;

        public static CoroutineRunner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject(nameof(CoroutineRunner)).AddComponent<CoroutineRunner>();
                }

                return instance;
            }
        }
    }
}
