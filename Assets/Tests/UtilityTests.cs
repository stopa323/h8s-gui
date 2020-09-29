using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using h8s;

namespace Tests
{
    [TestFixture]
    public class ScreenPositionTransformationTests
    {
        private GameObject root;

        static object[] CanvasPositionCases = {
            // Format:     Screen Size                Screen Position      Expected Canvas Position
            new object[] { new Vector2(1900f, 1080f), new Vector2(0f, 0f), new Vector2(0f, -1080f) },
            new object[] { new Vector2(1900f, 1080f), new Vector2(1900f, 1080f), new Vector2(1900f, 0f) },
            new object[] { new Vector2(1900f, 1080f), new Vector2(500f, 300f), new Vector2(500f, -780f) }
        };

        [SetUp]
        public void SetUp()
        {
            root = new GameObject();
            root.AddComponent<Canvas>();
            root.AddComponent<RectTransform>();
            root.AddComponent<BlackboardController>();
        }

        [TestCaseSource("CanvasPositionCases")]
        public void ScreenPositionIsProperlyTransformedToCanvasPosition(
            Vector2 canvasSize, Vector2 screenPosition, Vector2 expectedCanvasPosition)
        {
            var gui_rect = root.GetComponent<RectTransform>();
            gui_rect.sizeDelta = canvasSize;

            var computed_canvas_position = Utility.CanvasPositionFromScreen(screenPosition);

            Assert.AreEqual(expectedCanvasPosition, computed_canvas_position);
        }
    }
}
