using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using h8s;

namespace Tests
{
    [TestFixture]
    public class ResourceCreateTests
    {
        private GameObject root;
        private RectTransform nodeContainerTransform;
        private ResourceController controller;

        [SetUp]
        public void SetUp()
        {
            root = new GameObject();
            nodeContainerTransform = root.AddComponent<RectTransform>();

            controller = ScriptableObject.CreateInstance<ResourceController>();

            var node_prefab = new GameObject();
            node_prefab.AddComponent<h8s.element.Resource>();
            controller.ResourcePrefab = node_prefab;
        }

        [Test]
        public void ResourceElementIsCreated()
        {
            controller.CreateResource(Vector2.zero, nodeContainerTransform);

            Assert.AreEqual(1, controller.Registry.Count);
            Assert.AreEqual(1, nodeContainerTransform.childCount);
        }
    }
}
