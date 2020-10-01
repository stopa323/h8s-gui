using UnityEngine;
using UnityEngine.EventSystems;

namespace h8s
{
    public class BlackboardController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private ResourceController resourceController;
        [SerializeField] private RectTransform nodeContainer;

        public static Canvas GUICanvas { get; private set; }
        public static RectTransform GUICanvasRect { get; private set; }

        private void Awake()
        {
            /** Cache reference to major components **/
            GUICanvas = GetComponent<Canvas>();
            GUICanvasRect = GetComponent<RectTransform>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            switch(eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    var transformed_position = Utility.CanvasPositionFromScreen(eventData.position);
                    
                    // Todo: What if this will fail?
                    resourceController.CreateResource(transformed_position, nodeContainer);
                    break;
                default:
                    break;
            }
        }
    }
}
