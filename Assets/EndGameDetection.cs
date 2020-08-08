using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDetection : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "DieLayer")
		{
			DieAction();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "DieLayer")
		{
			DieAction();
		}
	}

	void DieAction()
	{
		MenuPanelManager menuPanelManager = MenuPanelManager.GetInstance();
		menuPanelManager.SwitchMenuPanel(MenuPanelType.EndGameLooseMenu);

	}
}
