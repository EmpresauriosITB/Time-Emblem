using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
	public Slider slider;

	public Image fill;

	public CharacterUnitController c;
	private int cooldownPeriod;
	

	private void Start()
	{
		slider.maxValue = c.currentVelocity + Time.time;
		slider.value = 0;
		cooldownPeriod = (int) c.timeToNextActivePeriod;
		
	}
	private void Update()
	{
		if(cooldownPeriod != (int) c.timeToNextActivePeriod)
		{
			
			slider.maxValue = c.currentVelocity + Time.time;
			slider.minValue = Time.time;
			cooldownPeriod = (int)c.timeToNextActivePeriod;
		}

		slider.value = Time.time;

	}
}
