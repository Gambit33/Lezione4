using UnityEngine;
using System.Collections;

public class SetGrafico : MonoBehaviour {

	private bool AFtf = true;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetOmbra (float SSO) 
	{
		QualitySettings.shadowDistance = SSO;
	}
	public void ChangeSliderQuality (float CST) 
	{
		if (CST == 3)
		{
			QualitySettings.masterTextureLimit = 0;
		}
		if (CST == 2) 
		{
			QualitySettings.masterTextureLimit = 1;
		}
		if (CST == 1) 
		{
			QualitySettings.masterTextureLimit = 2;
		}
		if (CST == 0)
		{
			QualitySettings.masterTextureLimit = 3;
		}
	}
}
