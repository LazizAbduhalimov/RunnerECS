using UnityEngine;

namespace RunnerECS
{
    public class RestartButtonTag : MonoBehaviour
    {
        private static RestartButtonTag _instance;

        private void Awake()
        {
            if (_instance != null)
                Destroy(gameObject);

            _instance = this;
        }        
    }
}
