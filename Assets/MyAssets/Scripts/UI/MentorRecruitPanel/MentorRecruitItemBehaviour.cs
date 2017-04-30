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

	private MstCharacter _chara; // mentorの情報が入っているクラス変数

	void Update ()
	{
		// もしメンターがまだ採用されておらず
		if (_chara.Hired == false)
		{
			// 所持金が雇用にかかる金額よりも大きい場合
			if (PlayerManager.instance.MyMoney >= _chara.InitialCost)
			{
				// ボタンを有効にする
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

			// Userの所持メンター一覧にメンターを追加
			PlayerManager.instance.MyMentors.Add(chara);

			// mentorのLevelを1に設定
			chara.Level = 1;

			// メンターの生産性を計算する
			chara.CaluculatePower();

			// Playerの生産性を計算し直す
			PlayerManager.instance.CaluculateMyProductivity();

			// テキストを"SOLD OUT"に変更し、ステータスHiredをtrueに
			_mentorRecruitCostValue.text = "SOLD OUT";
			_chara.Hired = true;

			// 雇用ボタンを無効にする
			_mentorRecruitButton.interactable = false;

			// TrainingItemをInstantiateする
			var item = MentorTrainingItemManager.instance.CreateItem(chara);

			// avatorをinstantiateする
			var avator = MentorAvatorManager.instance.CreateMentorAvator(chara);

			// Training Itemのクラス変数にavatorを設定
			item.GetComponent<MentorTrainingItemBehaviour>().SetAvator(avator);
        });
	}
}
