using UnityEngine;

namespace h8s
{
    public class ResourceController : MonoBehaviour
    {
        public static ResourceController Instance { get; private set; }

        [SerializeField] private GameObject resourcePrefab;

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); }
            else { Instance = this; }
        }

        public void CreateResource(Vector2 position)
        {
            Debug.Log(string.Format("Creating resource at {0}", position));

            // Spawn resource object attached to node container
            var node_obj = Instantiate(resourcePrefab, transform) as GameObject;

            // Move node to requested position
            var spawn_position = Utility.CanvasPositionFromScreen(position);
            Debug.Log(spawn_position);
            node_obj.transform.localPosition = new Vector3(spawn_position.x, spawn_position.y);
        }
    }
}
