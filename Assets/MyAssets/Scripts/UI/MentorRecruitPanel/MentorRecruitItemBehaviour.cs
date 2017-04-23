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

	private MstCharacter _chara;

	void Update ()
	{
		// もしメンターがまだ採用されておらず
		if (_chara.Hired == false)
		{
			// 所持金が雇用にかかる金額よりも大きい場合
			if (PlayerManager.instance.MyMoney >= _chara.InitialCost)
			{
				_mentorRecruitButton.interactable = true;
			}
		}
	}
	public void SetValues (MstCharacter chara) // MentorRecruitItemの値を入れていくメソッド
    {
		// クラス変数にcharaを代入
		_chara = chara;

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

	public void SetButtonFunction (MstCharacter chara) //InstantiateされたButtonにListernerを定義する
	{
		_mentorRecruitButton.onClick.AddListener (() => {
			// 所持金から雇用に使う金額を差し引く
			PlayerManager.instance.MyMoney -= _chara.InitialCost;

			// そのメンターの生産性をPlayerの生産性に足す
			PlayerManager.instance.MyProductivity += chara.LowerEnergy;

			// テキストを"SOLD OUT"に変更し、ステータスHiredをtrueに
			_mentorRecruitCostValue.text = "SOLD OUT";
			_chara.Hired = true;

			// 雇用ボタンを無効にする
			_mentorRecruitButton.interactable = false;

			// TrainingItemをInstantiateする
			MentorTrainingItemManager.instance.CreateItem(chara);
        });
	}
}
