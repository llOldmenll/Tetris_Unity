using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowBtnState : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

    [HideInInspector]
    public bool pressed = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
