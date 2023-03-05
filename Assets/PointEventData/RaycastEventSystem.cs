using UnityEngine;
using UnityEngine.EventSystems;

namespace PointEventData
{
    public class RaycastEventSystem : MonoBehaviour
    {
        RaycastHit hit;

        private GameObject prevButton;
        private GameObject currButton;

        void Update()
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                GazeButton();
                GazeObject();
            }
        }

        void GazeButton()
        {
            // 현재 시점의 포인터 이벤트 정보를 추출
            PointerEventData _data = new PointerEventData(EventSystem.current);

            // 현재 응시하고 있는 것이 버튼일 경우
            if (hit.collider.gameObject.layer == 5)
            {
                // 광선에 맞은 버튼을 현재 응시하는 버튼에 저장
                currButton = hit.collider.gameObject;

                // 이전 버튼과 현재 응시하는 버튼이 서로 다른 경우
                if (currButton != prevButton)
                {
                    // 현재 응시하는 버튼에 PointerEnter 이벤트 전달
                    ExecuteEvents.Execute(currButton, _data, ExecuteEvents.pointerEnterHandler);

                    // 이전에 응시했던 버튼에 PointerExit 이벤트 전달
                    ExecuteEvents.Execute(prevButton, _data, ExecuteEvents.pointerExitHandler);

                    // 이전 버튼의 정보를 갱신
                    prevButton = currButton;
                }
                else
                {
                    // 레티클이 버튼 이외의 다른 곳을 응시했을 때, 기존 버튼에 PointerExit 이벤트 전달
                    ReleaseButton();
                }
            }
        }

        // 레티클이 버튼 이외의 다른 곳을 응시했을 때, 기존 버튼을 초기화
        void ReleaseButton()
        {
            // 현재 시점의 포인터 이벤트 정보를 추출
            PointerEventData _data_ = new PointerEventData(EventSystem.current);

            // 이전에 응시했던 버튼이 있을 경우
            if (prevButton != null)
            {
                // 이전에 응시했던 버튼에 PointerExit 이벤트 전달
                ExecuteEvents.Execute(prevButton, _data_, ExecuteEvents.pointerExitHandler);

                prevButton = null;
            }
        }

        void GazeObject()
        {
            PointerEventData data = new PointerEventData(EventSystem.current);

            if (hit.collider.name == "Cube")
            {
                ExecuteEvents.Execute(hit.collider.gameObject, data, ExecuteEvents.pointerEnterHandler);
            }
        }
    }
}