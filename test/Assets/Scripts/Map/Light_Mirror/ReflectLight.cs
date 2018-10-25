using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectLight : MonoBehaviour {

	public GameObject Line;
	public GameObject oriPoint;
	public GameObject ReflectLightPrefab;
	public GameObject OriPointPrefab;
	public Vector3 Sc;
	public float rotateSpeed;
	public RaycastHit hitInfo;
	public bool isTheFirstLight = false;

	private Ray ray;
	private Vector3 dir;
	private Vector3 reflectLightDir;
	private GameObject reflectLight;
	private GameObject newLight;
	private GameObject newOri;
	private GameObject inLight;

	private void Awake() {
		if (oriPoint != null)
			dir = oriPoint.transform.forward;
	}


	void Update () {
		// 让光始终
		Rotating(dir.x, dir.z);

		if (oriPoint != null)
			ray = new Ray(oriPoint.transform.position, dir);

        if (Physics.Raycast(ray, out hitInfo, 9999, 1 << LayerMask.NameToLayer("Mirror"))) {
			// 遮挡
			Sc.y = hitInfo.distance;

			// 创建反射光
			reflectLightDir = Vector3.Reflect(dir, hitInfo.normal);
			if (reflectLight == null) {
				// 创建光
				newLight = Instantiate(ReflectLightPrefab, hitInfo.point, ReflectLightPrefab.transform.rotation);
				// 创建反射光的“光源”
				newOri = Instantiate(OriPointPrefab, hitInfo.point, OriPointPrefab.transform.rotation);
				// 设置反射光的各种参数
				newLight.GetComponent<ReflectLight>().oriPoint = newOri;
				newLight.GetComponent<ReflectLight>().dir = reflectLightDir;
				newLight.GetComponent<ReflectLight>().inLight = this.gameObject;
				newLight.GetComponent<ReflectLight>().isTheFirstLight = false;
				reflectLight = newLight;
			}

			// 调整反射光方向和反射点位置
			if (reflectLight != null) {
				reflectLight.GetComponent<ReflectLight>().dir = reflectLightDir;
				if (newOri != null)
					newOri.transform.position = hitInfo.point;
			}
			
			Debug.DrawLine(oriPoint.transform.position, hitInfo.point);
		}
		// 碰到其他的物体直接截断
		else if (Physics.Raycast(ray, out hitInfo)) {
			Sc.y = hitInfo.distance;
		}
		else {
			Sc.y = 100;		// 默认光线长度
		}

		// 没有照射到镜子上，取消反射
		if (!Physics.Raycast(ray, out hitInfo, 9999, 1 << LayerMask.NameToLayer("Mirror")) && reflectLight != null) {
			Destroy(newLight);
			Destroy(newOri);
		}

		// 没有入射光而且不是第一束光源，销毁自己
		if (inLight == null && !isTheFirstLight) {
			Destroy(this.gameObject);
		}
		// 让光始终从光源发出
		this.gameObject.transform.position = oriPoint.transform.position;
		// 改变光线长度
		Line.transform.localScale = Sc;
	}

	private void Rotating(float hor, float ver) {  
        Vector3 dir = new Vector3(hor, 0, ver);  
        Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.up);  
        transform.rotation = Quaternion.Lerp(transform.rotation, quaDir, Time.fixedDeltaTime * rotateSpeed);
    }
}
