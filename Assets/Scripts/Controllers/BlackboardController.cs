using UnityEngine;
using UnityEngine.EventSystems;

namespace h8s
{
    public class BlackboardController : MonoBehaviour, IPointerClickHandler
    {
        public static BlackboardController Instance { get; private set; }
        public static Canvas GUICanvas { get; private set; }
        public static RectTransform GUICanvasRect { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); }
            else { Instance = this; }

            /** Cache reference to major components **/
            GUICanvas = GetComponent<Canvas>();
            GUICanvasRect = GetComponent<RectTransform>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            switch(eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    ResourceController.Instance.CreateResource(eventData.position);
                    break;
                default:
                    break;
            }
        }
    }
}
