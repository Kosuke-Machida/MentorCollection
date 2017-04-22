using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentorRecruitItemBehaviour : MonoBehaviour {

	[SerializeField] private Image _mentorImage;
	[SerializeField] private Text _mentorName;
	[SerializeField] private Text _mentorFlavorText;
	[SerializeField] private Text _mentorLowerEnergy;
	[SerializeField] private Text _mentorRarity;
	[SerializeField] private Text _mentorRecruitCostValue;
	[SerializeField] private Button _mentorRecruitButton;
	[SerializeField] GameObject _mentorTrainingItem;
	[SerializeField] GameObject _mentorRecluitItemContent;
	public void CreateItem ()
	{
		Instantiate(
			_mentorTrainingItem,
			_mentorRecluitItemContent.transform.position,
			Quaternion.identity,
			_mentorRecluitItemContent.transform
		);
	}

	// MentorRecruitItemの値を入れていくメソッド
	public void SetValues (MstCharacter chara)
    {
		_mentorImage.sprite = Resources.Load<Sprite>("Face/" + chara.ImageId);
        _mentorName.text = chara.Name;
		_mentorFlavorText.text = chara.FlavorText;
		_mentorRarity.text = "";

		// Rarityはint型なのでfor文を回して値の数だけ"★"を入れる
		for (int i = 0; i < chara.Rarity; i++)
		{
			_mentorRarity.text += "★";
		}

		_mentorLowerEnergy.text = "生産性(lv.1)：" + chara.LowerEnergy.ToString();
		_mentorRecruitCostValue.text = string.Format("¥{0:#,0}", chara.InitialCost);
    }

	public void SetButtonFunction()
	{
		_mentorRecruitButton.onClick.AddListener (() => {
			_mentorRecruitCostValue.text = "SOLD OUT";
			_mentorRecruitButton.interactable = false;
			Instantiate(
				_mentorTrainingItem,
				_mentorRecluitItemContent.transform.position,
				Quaternion.identity,
				_mentorRecluitItemContent.transform
			);
        });
	}
}
