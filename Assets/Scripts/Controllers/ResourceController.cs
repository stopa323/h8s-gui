using System.Collections.Generic;
using UnityEngine;

namespace h8s
{
    [CreateAssetMenu(fileName = "ResourceController", menuName = "Scriptables/Controllers/ResourceController")]
    public class ResourceController : ScriptableObject
    {
        public GameObject ResourcePrefab;

        /* Container for all resource elements on the blackboard */
        public List<element.Resource> Registry { get; private set; }

        private void Awake()
        {
            Registry = new List<element.Resource>();
        }

        public void CreateResource(Vector2 position, RectTransform nodeContainer)
        {
            Debug.Log(string.Format("Creating resource at {0}", position));

            // Spawn resource object attached to node container
            var resource_object = Instantiate(ResourcePrefab, nodeContainer) as GameObject;
            
            // Move node to requested position
            resource_object.transform.localPosition = new Vector3(position.x, position.y);

            var resource = resource_object.GetComponent<element.Resource>();
            Registry.Add(resource);
        }
    }
}
