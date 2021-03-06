﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfoPanelBehavior : MonoBehaviour {
	[SerializeField] Text myMoneyText;
	[SerializeField] Text productivityBySecondText;
	[SerializeField] Text workersCountText;
	[SerializeField] Text myProductivity;
	private GameObject[] userInfoPanels;

	void Start ()
	{
		StartCoroutine ("FlashText");
	}

	void Update ()
	{
		//panel内のテキストを更新する
		 SetValues();
	}

	public void SetValues () //panel内のテキストを更新するメソッド
	{
		myMoneyText.text = "所持金 : " + string.Format("¥{0:#,0}", PlayerManager.instance.MyMoney);
		productivityBySecondText.text = "+" + string.Format("{0:#,0}", PlayerManager.instance.MyProductivity/2);
		workersCountText.text = "従業員 : " + PlayerManager.instance.MyMentors.Count.ToString() +"人";
		myProductivity.text = "生産性 : " + string.Format("¥{0:#,0}", PlayerManager.instance.MyProductivity);
	}

	private IEnumerator FlashText ()
	{
		while (true)
		{
			float alpha = productivityBySecondText.GetComponent<CanvasRenderer>().GetAlpha();
			if (alpha == 1.0f)
			{
				productivityBySecondText.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
			}
			else
			{
				productivityBySecondText.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
			}
			yield return new WaitForSeconds (0.5f);
		}
    }


}
