using UnityEngine;
using UnityEngine.UI;
using System;
// Aggiorna una combobox priva di Items nell'inspector
// By Alex "Nessuno" Cippini
// Modificato e revisionato e commentato by Tommaso "Proffe" Lintrami

// Un namespace serve a limitare i conflitti tra nomi di classi simili all'interno della classe, a proteggerla in un certo qual senso da eventuali conflitti 
// (pensate al Text della vecchia gui e al nuovo Text o altri casi)
// Qui l'autore iniziale, ha usato un name space separato da punto (suonome.uGUI) dove uGUI sta per Unity GUI. 
// Questo consente di avere un namespace principale per le proprie classi, e un secondario per le "cose" relate alla Unity GUI.
namespace Kender.uGUI
{
	public class MenuController : MonoBehaviour
	{
		// Specifica nell'inspector quale ComboBox deve essere popolato dalla lista di risoluzioni video a disposizione
		//public ComboBox myComboBox; // <--  questo non serve che sia publico, se si aggancia questo componente direttamente al ComboBox interessato. (vedi funzione Start() )
		private ComboBox myComboBox;
		public Sprite customImage;
		private bool AFtf = true;
		public Slider qSlider;
		public Slider sdSlider;
		public bool expensiveQualitySettings = true;
		public Text qLabel;
		public Slider masterAudioSlider;

		// Specifica il checkbox che gestisce il settaggio fullscreen o meno 
		//public Toggle myCheckBox;
		// sprite alternativo da inserire di fianco al testo della risoluzione (specificare uno, viene applicato a tutti gli elementi)
		//public Sprite customImage;
		
		// Array stringa contenente il testo da mettere negli elementi della combo box.
		private String[] strQualvideo;
		// Array comboboxitem da passare alla myComboBox.AddItems
		private ComboBoxItem[] myCBItems;
		// Variabile che conterrà la collezione delle risoluzioni video disponibili
		//private Resolution[] risoluzioniVideo;
		private int indiceVideoQualAttuale;
		private bool fullscreen;
		
		void Start ()
		{
			qSlider.maxValue = QualitySettings.names.Length -1;
			qSlider.value = QualitySettings.GetQualityLevel ();
			masterAudioSlider.onValueChanged.AddListener( (value) => { AudioListener.volume = value;} );
			sdSlider.onValueChanged.AddListener( (value) => { QualitySettings.shadowDistance = value;} );
			qSlider.onValueChanged.AddListener( (value) => {
				int qsi = Mathf.RoundToInt (value);
				QualitySettings.SetQualityLevel (qsi);
				qLabel.text = QualitySettings.names [qsi];
				sdSlider.value = QualitySettings.shadowDistance;  } );

			myComboBox = this.gameObject.GetComponent<ComboBox>();
			strQualvideo = QualitySettings.names;
			
			if (strQualvideo != null) // && myComboBox !=null)
			{
				myCBItems = new ComboBoxItem[strQualvideo.Length];
				for (int i = 0; i < strQualvideo.Length; i++) 
				{
					myCBItems[i] = new ComboBoxItem (strQualvideo[i], customImage, false);
				}
				myComboBox.AddItems (myCBItems);
			}
			indiceVideoQualAttuale = QualitySettings.GetQualityLevel();
			myComboBox.SelectedIndex = indiceVideoQualAttuale;
			QualitySettings.SetQualityLevel(indiceVideoQualAttuale);
			
		}
		
		public void SetVideoQual ()
		{
			indiceVideoQualAttuale = myComboBox.SelectedIndex;
			QualitySettings.SetQualityLevel ( indiceVideoQualAttuale); 
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

		/*public void SetQuality (float qs) 
		{
			int qsi = Mathf.RoundToInt (qs);
			QualitySettings.SetQualityLevel (qsi);
			qLabel.text = QualitySettings.names [qsi];
			sdSlider.value = QualitySettings.shadowDistance;
		}

		public void SetShadowDistance (float dist) 
		{
			QualitySettings.shadowDistance = dist;
		}*/
		
	}
}
