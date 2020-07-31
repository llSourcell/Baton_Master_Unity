using Madhur.InfoPopup;
using UnityEngine;

/// <summary>
/// Demo class to showcase the POP UP Slider
/// </summary>
public class Demo : MonoBehaviour
{
    [SerializeField]
    string Text;
    void Update()
    {
        if( Input.GetKeyUp( KeyCode.A ))
		{
			// TO show Information popup
			InfoPopupUtil.ShowInformation ( "50 Coins received" );
		}

		if ( Input.GetKeyUp ( KeyCode.S ) )
		{
			// TO show warning popup
			InfoPopupUtil.ShowWarning( "Achievement Unlocked : Coder");
		}

		if ( Input.GetKeyUp ( KeyCode.D ) )
		{
			// TO show Alert popup
			InfoPopupUtil.ShowAlert( "Achievement Unlocked : Help Me!!!" );
		}

        if( Input.GetKeyUp(KeyCode.F))
        {
            InfoPopupUtil.ShowInformation(Text);
        }
	}
}
