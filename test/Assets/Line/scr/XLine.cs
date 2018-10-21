using UnityEngine;
using System.Collections;

public class XLine : MonoBehaviour {
	public GameObject Line;
	public GameObject oriPoint;
	public Vector3 Sc;

	private Ray ray;

	void Update () {
		RaycastHit hitInfo;
		ray = new Ray(oriPoint.transform.position, oriPoint.transform.forward);
        if (Physics.Raycast(ray, out hitInfo)) {
			Sc.y = hitInfo.distance;
			Debug.DrawLine(oriPoint.transform.position, hitInfo.point);
		}
		else{
			Sc.y = 100;
		}
			
		Line.transform.localScale = Sc;
            
	}
}
