using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
	public Slider slider;

	public Image fill;

	public CharacterUnitController c;

	private void Start()
	{
		slider.maxValue = c.currentHp;
		slider.value = c.currentHp;
	}
	private void Update()
	{
		slider.value = c.currentHp;

	}

}
