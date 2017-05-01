using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {
	public static CameraManager instance;
	[SerializeField] private GameObject mainCamera;
	[SerializeField] private GameObject normalStateUI;
	[SerializeField] private GameObject vrViewUI;
	[SerializeField] private GameObject mentorViewUI;
	[SerializeField] private Text mentorViewNameText;
	[SerializeField] private Text mentorViewExplanationText;
	[SerializeField] private Button backFromDiveToMainButton;
	[SerializeField] private Button backFromMentorToMainButton;
	private GameObject avator;

	void Start ()
	{
		// singleton化
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad (instance.gameObject);
		}
	}
	public void SwitchFromMainToVive (GameObject _avator)
	{
		// avatorをクラス変数に格納
		avator = _avator;

		// ボタンに処理を記述
		backFromDiveToMainButton.onClick.AddListener (() => {
			avator.GetComponent<MentorAvatorBehavior>().FinishVRView();
        });

		// 通常画面用のGUIを無効にする
		normalStateUI.SetActive(false);

		// MainCameraを無効にする
		mainCamera.SetActive(false);

		// mentorに紐づいたDiveCameraを有効にする
		avator.GetComponent<MentorAvatorBehavior>().DiveCamera.SetActive(true);

		// VR View画面用のGUIを有効にする
		vrViewUI.SetActive(true);
	}

	public void SwitchFromDiveToMain ()
	{
		// VR View画面用のGUIを無効にする
		vrViewUI.SetActive(false);

		// Dive Cameraを無効にする
		avator.GetComponent<MentorAvatorBehavior>().DiveCamera.SetActive(false);

		// MainCameraを有効にする
		mainCamera.SetActive(true);

		// 通常画面用のGUIを有効にする
		normalStateUI.SetActive(true);

		// クラス変数をリセット
		avator = null;
	}

	public void SwitchFromMainToMentor (GameObject _avator)
	{
		print("わーいわーい");
		// avatorをクラス変数に格納
		avator = _avator;

		// ボタンに処理を記述
		backFromMentorToMainButton.onClick.AddListener (() => {
			SwitchFromMentorToMain();
        });

		// 通常画面用のGUIを無効にする
		normalStateUI.SetActive(false);

		// MainCameraを無効にする
		mainCamera.SetActive(false);

		// GUIに値を設定
		MstCharacter chara = avator.GetComponent<MentorAvatorBehavior>().Chara;
		mentorViewNameText.text = chara.Name;
		mentorViewExplanationText.text = chara.FlavorText;

		// mentorに紐づいたDiveCameraを有効にする
		avator.GetComponent<MentorAvatorBehavior>().MentorCamera.SetActive(true);

		// VR View画面用のGUIを有効にする
		mentorViewUI.SetActive(true);
	}

	public void SwitchFromMentorToMain ()
	{
		// VR View画面用のGUIを無効にする
		mentorViewUI.SetActive(false);

		//Dive Cameraを無効にする
		avator.GetComponent<MentorAvatorBehavior>().MentorCamera.SetActive(false);

		// MainCameraを有効にする
		mainCamera.SetActive(true);

		// 通常画面用のGUIを有効にする
		normalStateUI.SetActive(true);

		// クラス変数をリセット
		avator = null;
	}
}
