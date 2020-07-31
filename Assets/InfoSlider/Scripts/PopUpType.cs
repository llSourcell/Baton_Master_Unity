using UnityEngine;

namespace Madhur.SO.PopUp
{
	[CreateAssetMenu ( fileName = "Popup-Type-" , menuName = "InfoPopup/Popup Type" )]
	public class PopUpType : ScriptableObject
	{
        [Header("Panel")]
        public Sprite PanelBase = null;

        public Color PanelColor = Color.white;

        /// <summary>
        /// Icon on the popup
        /// </summary>
		[Header("Icon")]
		public  Sprite				Image = null;

        /// <summary>
        /// Customizations. 
        /// Should this popup draw image
        /// </summary>
        [Header("Customizations")]
        public bool                 DrawImage = true;

        /// <summary>
        /// Font style for the text
        /// </summary>
		public  TMPro.FontStyles    Style = TMPro.FontStyles.Normal;

		// If there is any other customization you want to add, 
		// ADD BELOW 

	}

}