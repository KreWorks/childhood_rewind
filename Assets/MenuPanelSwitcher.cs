using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuPanelSwitcher : MonoBehaviour
{
	public MenuPanelType desiredPanelType;

	MenuPanelManager menuPanelManager;
	Button menuButton;

    // Start is called before the first frame update
    void Start()
    {
		menuButton = GetComponent<Button>();
		menuButton.onClick.AddListener(OnButtonClicked);
		menuPanelManager = MenuPanelManager.GetInstance();
    }

	void OnButtonClicked()
	{
		menuPanelManager.SwitchMenuPanel(desiredPanelType);
	}
}
