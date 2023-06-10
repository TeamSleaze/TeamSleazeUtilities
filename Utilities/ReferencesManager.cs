using UnityEngine;

namespace TeamSleaze.Utilities
{
    public class ReferencesManager : MonoBehaviour
    {
        public static ReferencesManager Instance;

        public GameObject Player;


        private void Start()
        {
            Instance = this;

            Player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
    }
}