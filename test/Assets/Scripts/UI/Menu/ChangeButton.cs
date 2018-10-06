using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Sprite texture1;
	public Sprite texture2;

	public void OnPointerEnter(PointerEventData eventData) {
        gameObject.GetComponent<Image>().sprite = texture2;
    }

	public void OnPointerExit(PointerEventData eventData){
        gameObject.GetComponent<Image>().sprite = texture1;
    }

    public void ChangeBack() {
        gameObject.GetComponent<Image>().sprite = texture1;
    }
	
}
