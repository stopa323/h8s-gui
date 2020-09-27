using UnityEngine;

namespace h8s
{
    public static class Utility
    {
        public static Vector2 CanvasPositionFromScreen(Vector2 screenPosition)
        {
            var transformed_position = new Vector2(
                screenPosition.x, 
                screenPosition.y - BlackboardController.GUICanvasRect.rect.height);

            return transformed_position;
        }
    }

}
