using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InformationManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField schoolInputField;
    [SerializeField] private TMP_InputField classInputField;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_Dropdown dropdown;

    private GameObject schoolErrorText;
    private GameObject classErrorText;
    private GameObject nameErrorText;
    public GameObject prompt;
    public TextMeshProUGUI informationConfirm;
    public TextMeshProUGUI nameConfirm;

    public Button submitBtn;
    public Button informationSubmitBtn; // 정보 확인 버튼

    public int currentClass = -1;
    public string spareClass = null;
    public string currentName = null;
    public string currentSchool = null;

    public string[] gradeList = new string[6] { "1학년", "2학년", "3학년", "4학년", "5학년", "6학년" };
    public int gradeIndex = 0;
    public string grade;

    private int count = 0;

    private bool schoolError = false;
    private bool classError = false;
    private bool nameError = false;

    public GameObject StartCanvas;
    public GameObject InformationCanvas;
    public GameObject ProblemCanvas;
    public GameObject CertificateCanvas;

    private void Awake()
    {
        StartCanvas.SetActive(false);
        InformationCanvas.SetActive(true);
        ProblemCanvas.SetActive(false);
        CertificateCanvas.SetActive(false);

        prompt = GameObject.Find("Popup").transform.Find("EmptyPopup").gameObject;
        prompt.SetActive(false);

        grade = gradeList[gradeIndex];
        schoolErrorText = GameObject.Find("SchoolError");
        classErrorText = GameObject.Find("ClassError");
        nameErrorText = GameObject.Find("NameError");
        schoolErrorText.SetActive(false);
        classErrorText.SetActive(false);
        nameErrorText.SetActive(false);
        dropdown.onValueChanged.AddListener(OnDropdownEvent);
    }
    public void OnDropdownEvent(int index)
    {
        gradeIndex = index;
        grade = gradeList[gradeIndex];
        //Debug.Log(grade);
    }

    [System.Obsolete]
    public void Start()
    {
        classInputField.onValueChanged.AddListener(GetClassNumber);
        classInputField.onEndEdit.AddListener(GetClassNumber);
        classInputField.onDeselect.AddListener(GetClassNumber);

        nameInputField.onValueChanged.AddListener(GetName);
        nameInputField.onEndEdit.AddListener(GetName);
        nameInputField.onDeselect.AddListener(GetName);

        schoolInputField.onValueChanged.AddListener(GetSchool);
        schoolInputField.onEndEdit.AddListener(GetSchool);
        schoolInputField.onDeselect.AddListener(GetSchool);

        submitBtn.onClick.AddListener(Input);

        informationSubmitBtn.onClick.AddListener(SubmitInformation);
    }

    public void Input()
    {
        count++;

        if (count > 0 && (spareClass is null || spareClass.Length == 0))
        {
            classError = true;
            classErrorText.SetActive(true);
        }
        else
        {
            classError = false;
            classErrorText.SetActive(false);
        }

        if (count > 0 && (currentName is null || currentName.Length == 0))
        {
            nameError = true;
            nameErrorText.SetActive(true);
        }
        else
        {
            nameError = false;
            nameErrorText.SetActive(false);
        }

        if (count > 0 && (currentSchool is null || currentSchool.Length == 0))
        {
            schoolError = true;
            schoolErrorText.SetActive(true);
        }
        else
        {
            schoolError = false;
            schoolErrorText.SetActive(false);
        }

        if (count > 0 && !classError && !nameError && !schoolError)
        {
            currentClass = int.Parse(spareClass);
            informationConfirm.text = currentSchool + "  " + grade + "  " + currentClass.ToString() + "반" + "  ";
            nameConfirm.text = currentName;
            prompt.SetActive(true);
        }
    }

    public void SubmitInformation()
    {
        InformationCanvas.SetActive(false);
        ProblemCanvas.SetActive(true);
        //SceneManager.LoadScene(9);
    }

    public void GetClassNumber(string str)
    {
        spareClass = str;
    }

    public void GetName(string str)
    {
        currentName = str;
    }

    public void GetSchool(string str)
    {
        currentSchool = str;
    }
}
