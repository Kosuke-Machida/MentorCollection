using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MentorTrainingItemBehaviour : MonoBehaviour {

    [SerializeField] private Image _mentorImage;
	[SerializeField] private Text _mentorName;
	[SerializeField] private Text _mentorFlavorText;
	[SerializeField] private Text _mentorLowerEnergy;
	[SerializeField] private Text _mentorRarity;

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
    }

}
