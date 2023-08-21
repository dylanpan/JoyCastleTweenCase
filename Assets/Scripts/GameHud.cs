using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Joy.Tweening;

public class GameHud : MonoBehaviour
{
    public GameObject DOTweenCube;
    public Dropdown DOTweenDropdown;
    public Button DOTweenResetBtn;
    public Button DOTweenKillBtn;
    public Button DOTweenMoveBtn;
    public Button DOTweenScaleBtn;

    public GameObject JoyTweenCube;
    public Dropdown JoyTweenDropdown;
    public Button JoyTweenResetBtn;
    public Button JoyTweenKillBtn;
    public Button JoyTweenMoveBtn;
    public Button JoyTweenScaleBtn;

    private List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
    private float targetDuration = 6;
    private Vector3 targetScaleVector = new Vector3(3, 3, 3);
    private float targetPosY = 5;
    private float targetPosZ = 5;
    private Ease _dotweenEase = Ease.Linear;
    private JoyEase _joytweenEase = JoyEase.Linear;

    // Start is called before the first frame update
    void Start()
    {
        JoyTweenComponent.Instance.Init();
        InitEaseOptions();

        AddDOTweenBtnListener();
    
        AddJoyTweenBtnListener();
    }

    void InitEaseOptions()
    {
        options.Clear();
        options.Add(new Dropdown.OptionData("Linear"));
        options.Add(new Dropdown.OptionData("InSine"));
        options.Add(new Dropdown.OptionData("OutSine"));
        options.Add(new Dropdown.OptionData("InOutSine"));
        options.Add(new Dropdown.OptionData("InBack"));
        options.Add(new Dropdown.OptionData("OutBack"));
        options.Add(new Dropdown.OptionData("InOutBack"));
        DOTweenDropdown.options = options;
        DOTweenDropdown.onValueChanged.AddListener(OnDOTweenDropdownValueChanged);
        JoyTweenDropdown.options = options;
        JoyTweenDropdown.onValueChanged.AddListener(OnJoyTweenDropdownValueChanged);
        
    }

    #region DOTweenGroup
    void AddDOTweenBtnListener()
    {
        DOTweenResetBtn.onClick.AddListener(OnDOTweenResetBtnClick);
        DOTweenKillBtn.onClick.AddListener(OnDOTweenKillBtnClick);
        DOTweenMoveBtn.onClick.AddListener(OnDOTweenMoveBtnClick);
        DOTweenScaleBtn.onClick.AddListener(OnDOTweenScaleBtnClick);
    }

    private void OnDOTweenDropdownValueChanged(int index)
    {
        switch (index)
        {
            case 0:
            {
                _dotweenEase = Ease.Linear;
                break;
            }
            case 1:
            {
                _dotweenEase = Ease.InSine;
                break;
            }
            case 2:
            {
                _dotweenEase = Ease.OutSine;
                break;
            }
            case 3:
            {
                _dotweenEase = Ease.InOutSine;
                break;
            }
            case 4:
            {
                _dotweenEase = Ease.InBack;
                break;
            }
            case 5:
            {
                _dotweenEase = Ease.OutBack;
                break;
            }
            case 6:
            {
                _dotweenEase = Ease.InOutBack;
                break;
            }
        }
    }

    void OnDOTweenKillBtnClick()
    {
        DOTween.Kill(Const.DOTweenCubeTag);

        OnJoyTweenKillBtnClick();
    }
    void OnDOTweenResetBtnClick()
    {
        DOTweenCube.transform.localPosition = new Vector3(1.7f,0,0);
        DOTweenCube.transform.localScale = new Vector3(1,1,1);

        OnJoyTweenResetBtnClick();
    }
    void OnDOTweenMoveBtnClick()
    {
        DOTween.Kill(Const.DOTweenCubeTag);
        DOTweenCube.transform
            .DOMove(new Vector3(1.7f, targetPosY, targetPosZ), targetDuration)
            .SetEase(_dotweenEase)
            .SetId(Const.DOTweenCubeTag);

        OnJoyTweenMoveBtnClick();
    }
    void OnDOTweenScaleBtnClick()
    {
        DOTween.Kill(Const.DOTweenCubeTag);
        DOTweenCube.transform
            .DOScale(targetScaleVector, targetDuration)
            .SetEase(_dotweenEase)
            .SetId(Const.DOTweenCubeTag);

        OnJoyTweenScaleBtnClick();
    }
    #endregion

    #region JoyTweenGroup
    void AddJoyTweenBtnListener()
    {
        JoyTweenResetBtn.onClick.AddListener(OnJoyTweenResetBtnClick);
        JoyTweenKillBtn.onClick.AddListener(OnJoyTweenKillBtnClick);
        JoyTweenMoveBtn.onClick.AddListener(OnJoyTweenMoveBtnClick);
        JoyTweenScaleBtn.onClick.AddListener(OnJoyTweenScaleBtnClick);
    }

    private void OnJoyTweenDropdownValueChanged(int index)
    {
        _joytweenEase = (JoyEase)index;
    }

    void OnJoyTweenKillBtnClick()
    {
        JoyTween.Kill(Const.JoyTweenCubeTag);
    }
    void OnJoyTweenResetBtnClick()
    {
        JoyTweenCube.transform.localPosition = new Vector3(-1.7f,0,0);
        JoyTweenCube.transform.localScale = new Vector3(1,1,1);
    }
    void OnJoyTweenMoveBtnClick()
    {
        JoyTween.Kill(Const.JoyTweenCubeTag);
        JoyTweenCube.transform
            .JoyMove(new Vector3(-1.7f, targetPosY, targetPosZ), targetDuration)
            .SetJoyEase(_joytweenEase)
            .SetJoyId(Const.JoyTweenCubeTag);
        
        JoyTween.To(() => JoyTweenCube.transform.localPosition, x => JoyTweenCube.transform.localPosition = x, new Vector3(-1.7f, targetPosY, targetPosZ), targetDuration, Const.JoyTweenCubeTag);
    }
    void OnJoyTweenScaleBtnClick()
    {
        JoyTween.Kill(Const.JoyTweenCubeTag);
        JoyTweenCube.transform
            .JoyScale(targetScaleVector, targetDuration)
            .SetJoyEase(_joytweenEase)
            .SetJoyId(Const.JoyTweenCubeTag);

        // JoyTween.To(() => JoyTweenCube.transform.localScale, x => JoyTweenCube.transform.localScale = x, targetScaleVector, targetDuration, Const.JoyTweenCubeTag);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        
    }
}
