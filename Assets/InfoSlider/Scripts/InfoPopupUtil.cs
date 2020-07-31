using Madhur.SO.PopUp;
using UnityEngine;

namespace Madhur.InfoPopup
{
	public class InfoPopupUtil : MonoBehaviour
	{
		static InfoHandler m_infoHandler = null;

		public PopUpType      InfoPopup;

		public PopUpType      WarningPopup;

		public PopUpType      AlertPopup;

		private static InfoPopupUtil   _instance = null;

		void Awake ()
		{
			_instance = this;
		}

		public static void ShowInformation ( string a_Message )
		{
			Setup ( );
			m_infoHandler.ShowPopUp ( a_Message , _instance.InfoPopup );

		}

		public static void ShowWarning( string a_Message)
		{
			Setup ( );
			m_infoHandler.ShowPopUp ( a_Message , _instance.WarningPopup );

		}

		public static void ShowAlert( string a_Message )
		{
			Setup ( );
			m_infoHandler.ShowPopUp ( a_Message , _instance.AlertPopup );

		}


		public static void Setup()
		{
			Debug.Assert ( _instance != null , "InfoPopupUtil isntance not found in scene." );
			if ( m_infoHandler == null )
			{
				m_infoHandler = GameObject.FindObjectOfType<InfoHandler> ( );
				Debug.Assert ( m_infoHandler != null , "InfoHandler instance not found in scene" );
			}
		}

	}

}