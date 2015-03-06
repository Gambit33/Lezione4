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
	public class ResCtrlbyCB : MonoBehaviour
	{
		// Specifica nell'inspector quale ComboBox deve essere popolato dalla lista di risoluzioni video a disposizione
		//public ComboBox myComboBox; // <--  questo non serve che sia publico, se si aggancia questo componente direttamente al ComboBox interessato. (vedi funzione Start() )
		private ComboBox myComboBox;

		// Specifica il checkbox che gestisce il settaggio fullscreen o meno 
		public Toggle myCheckBox;
		// sprite alternativo da inserire di fianco al testo della risoluzione (specificare uno, viene applicato a tutti gli elementi)
		public Sprite customImage;
		
		// Array stringa contenente il testo da mettere negli elementi della combo box.
		private String[] strVideoRes;
		// Array comboboxitem da passare alla myComboBox.AddItems
		private ComboBoxItem[] myCBItems;
		// Variabile che conterrà la collezione delle risoluzioni video disponibili
		private Resolution[] risoluzioniVideo;
		private int indiceVideoResAttuale;
		private bool fullscreen;

		void Start ()
		{
			// Recuper le risoluzioni video disponibili sull'hardware del client
			risoluzioniVideo = Screen.resolutions;
			Debug.Log ("totale risoluzioni video disponibili:" + risoluzioniVideo.Length);

			myComboBox = this.gameObject.GetComponent<ComboBox>();

			if (risoluzioniVideo != null) // && myComboBox !=null)
			{
				strVideoRes = new string[risoluzioniVideo.Length];
				myCBItems = new ComboBoxItem[risoluzioniVideo.Length];
				for (int i = 0; i < risoluzioniVideo.Length; i++) 
				{
					strVideoRes[i] = risoluzioniVideo[i].width + "x" + risoluzioniVideo[i].height;
					myCBItems[i] = new ComboBoxItem (strVideoRes[i], customImage, false);
					Debug.Log(strVideoRes[i]);
				}
				myComboBox.AddItems (myCBItems);
			}

		}

		public void SetFullscreen( bool flag )
		{
			fullscreen = flag;
		}

		public void SetVideoRes ()
		{
			indiceVideoResAttuale = myComboBox.SelectedIndex;
			Screen.SetResolution (risoluzioniVideo [indiceVideoResAttuale].width, risoluzioniVideo [indiceVideoResAttuale].height, fullscreen); 
		}

	}
}
