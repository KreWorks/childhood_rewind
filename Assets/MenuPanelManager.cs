using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuPanelManager : Singleton<MenuPanelManager>
{
	List<MenuPanelController> menuPanelControllerList;
	MenuPanelController lastActivePanel;

    protected override void Awake()
	{
		base.Awake();

		menuPanelControllerList = new List<MenuPanelController>();
		menuPanelControllerList = GetComponentsInChildren<MenuPanelController>().ToList();

		foreach(MenuPanelController mpc in menuPanelControllerList)
		{
			mpc.gameObject.SetActive(false);
		}

		SwitchMenuPanel(MenuPanelType.MainMenu);
	}

	public void SwitchMenuPanel(MenuPanelType _type)
	{
		if(lastActivePanel != null)
		{
			lastActivePanel.gameObject.SetActive(false);
		}

		if(_type == MenuPanelType.EndGameLooseMenu || _type == MenuPanelType.EndGameWinMenu || _type == MenuPanelType.MainMenu)
		{
			Time.timeScale = 0;
		}

		MenuPanelController desiredPanel = menuPanelControllerList.Find(x => x.menuType == _type);
		if(desiredPanel != null)
		{
			desiredPanel.gameObject.SetActive(true);
			lastActivePanel = desiredPanel;
		}
		else
		{
			Debug.LogWarning("The desired panel was not found!" + _type);
		}
	}

	public bool IsActivePanel(MenuPanelType _type)
	{
		if (lastActivePanel != null)
		{
			return lastActivePanel.menuType == _type;
		}

		return false;
	}

	public void CloseMenu()
	{
		if(lastActivePanel != null)
		{
			lastActivePanel.gameObject.SetActive(false);
			lastActivePanel = null;
		}
	}
}
