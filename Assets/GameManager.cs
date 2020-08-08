using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public TMP_Text startGameButtonText;

	public RotateCounter casette;
	public HandController pen;

	List<int> records;

    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 0;
		startGameButtonText.text = "Start Game";

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuPanelManager menuPanelManager = MenuPanelManager.GetInstance();
			if (menuPanelManager.IsActivePanel(MenuPanelType.MainMenu))
			{
				Time.timeScale = 1;
				startGameButtonText.text = "Start Game";
				menuPanelManager.CloseMenu();
			}
			else
			{
				Time.timeScale = 0;
				startGameButtonText.text = "Resume Game";
				menuPanelManager.SwitchMenuPanel(MenuPanelType.MainMenu);
			}

		}
	}

	public void QuitAction()
	{
		Application.Quit();
	}

	public void StartGame()
	{
		Time.timeScale = 1;

		MenuPanelManager menuPanelManager = MenuPanelManager.GetInstance();
		menuPanelManager.CloseMenu();
	}

	public void RestartGame()
	{
		startGameButtonText.text = "Start Game";
		RotateCounter rc = FindObjectOfType<RotateCounter>();
		rc.ResetStartCondition();

		MenuPanelManager menuPanelManager = MenuPanelManager.GetInstance();
		menuPanelManager.CloseMenu();

		casette.ResetStartCondition();
		pen.ResetStartCondition();
	}
}
