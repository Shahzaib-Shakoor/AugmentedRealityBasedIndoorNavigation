using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();
    [SerializeField]
    private Slider navigationYOffset;

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;

    public SearchableDropDown SearchableDropDown;
    private List<string> options = new List<string>();
    private bool lineToggle = false;
    private int currentFloor = 0;

    // Start is called before the first frame update
    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    // Update is called once per frame
    private void Update()
    {
        if (lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            Vector3[] calculatedPathAndOffset = AddLineOffset();
            line.SetPositions(calculatedPathAndOffset);
        }
    }
    public void SetCurrentNavigationTarget(string selectedValue)
    {
        targetPosition = Vector3.zero;
        string selectedText = selectedValue;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        if (currentTarget != null)
        {
            if (!line.enabled)
            {
                ToggleVisibility();
            }
            targetPosition = currentTarget.PositionObject.transform.position;
        }
    }
    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }

    public void ChangeActiveFloor(int floorNumber)
    {
        currentFloor = floorNumber;
        SetNavigationTargetDropDownOptions(currentFloor);
    }

    private void SetNavigationTargetDropDownOptions(int floorNumber)
    {
        options.Clear();
        SearchableDropDown.ClearDropdown();

        if (line.enabled)
        {
            ToggleVisibility();
        }

        if (floorNumber == 0)
        {
            options.Add("HOD Office");
            options.Add("Main Entrance");
            options.Add("Potohar Lab 2");
            options.Add("Potohar Lab 1");
            options.Add("Mens Room (Ground Floor)");
            options.Add("Power Systems Lab");
            options.Add("Room G-22A");
            options.Add("Room G-23A");
            options.Add("Machine Lab");
            options.Add("Room G-20");
            options.Add("Room G-19");
            options.Add("Academic Office");
            options.Add("Room G-15");
            options.Add("Meeting Room");
            options.Add("Girls Common Room (Ground Floor)");
            options.Add("Room G-26");
            options.Add("Room G-27");
            options.Add("Room G-30");
            options.Add("Room G-33");
            options.Add("Room G-34");
            options.Add("Room G-32");
            options.Add("Room G-31");
            options.Add("Room G-29");
            options.Add("Room G-28");
            options.Add("Room G-03");
            options.Add("Prof Ata ul Aziz Office");
            options.Add("Prof Sana Saleh Office");
            options.Add("Prof Maria Nasir Office");
            options.Add("Prof Momal Bukhari Office");
            options.Add("Prof Faryal Gulla Office");
            options.Add("Faculty Kitchen (Ground Floor)");
            options.Add("Faculty Mens Room (Ground Floor)");
            options.Add("Prof Mukhtarullah Office");
            options.Add("Prof Amir Hafeez Office");
            options.Add("Prof Amir Muneer Office");
            options.Add("Ground Floor Stairs");
        }

        if (floorNumber == 1)
        {
            options.Add("Faculty Lounge");
            options.Add("Physics Lab");
            options.Add("FeedBack Lab");
            options.Add("Electronics Lab");
            options.Add("Circuit Lab");
            options.Add("Kohsar Lab");
            options.Add("IC Design Lab");
            options.Add("Radio Frequency Circuit System and Sensors Lab");
            options.Add("Maker Lab");
            options.Add("Computer Server Room");
            options.Add("Prof Khalilullah Office");
            options.Add("Room B-117");
            options.Add("Room B-126");
            options.Add("Room B-127");
            options.Add("Room B-130");
            options.Add("Room B-129");
            options.Add("Room B-132A");
            options.Add("Communication and Antenna Lab");
            options.Add("Mens Room");
            options.Add("Room B-122A");
            options.Add("Room B-123A");
            options.Add("Prof Niaz Ahmed Office");
            options.Add("Prof Muhammad Saeed Office");
            options.Add("Prof Arshad Hassan Office");
            options.Add("Prof Awais Ayub Office");
            options.Add("Prof Waseem Ikram Office");
            options.Add("Prof Muhammad Jafar Office");
            options.Add("Prof Shahid Qureshi Office");
            options.Add("Prof Muhammad Ibrar Office");
            options.Add("Prof Shahzad Saleem Office");
            options.Add("Prof Shahzad Ahmad Office");
            options.Add("Prof Azhar Rauf Office");
            options.Add("Prof Farhan Khalid Office");
            options.Add("Faculty Mens Room");
            options.Add("Ladies Room");
            options.Add("Stairs");
        }

        if (floorNumber == 2)
        {
            options.Add("Visiting Ficulty Lounge");
            options.Add("Room B-231");
            options.Add("Room B-232");
            options.Add("Room B-229");
            options.Add("Rohtas Lab");
            options.Add("Room B-225");
            options.Add("Ladies Room (2nd Floor)");
            options.Add("Room B-226");
            options.Add("Room B-227");
            options.Add("Room B-230");
            options.Add("Room B-232A");
            options.Add("Prof Hamda Khan Office");
            options.Add("Room B-212A");
            options.Add("Prof Khadija Farooq Office");
            options.Add("Prof Sara Aziz Office");
            options.Add("Faculty Mens Room (2nd Floor)");
            options.Add("Prof Aisha ijaz Office");
            options.Add("Prof Mehwish Hassan Office");
            options.Add("Faculty Ladies Room (2nd Floor)");
            options.Add("Prof Tayyab Nadeem Office");
            options.Add("Prof Usman Ashraf Office");
            options.Add("Prof Muhammad Ali Office");
            options.Add("Prof Irfan Shah Office");
            options.Add("Prof Muhammad Ibrahim Office");
            options.Add("Prof Shahzad Mahmood Office");
            options.Add("EPIC Lab");
            options.Add("Huawei Lab");
            options.Add("TDA Lab");
            options.Add("SEAL Lab");
            options.Add("IPC Lab");
            options.Add("DLD Lab");
            options.Add("Room B-222");
            options.Add("Room B-220");
            options.Add("Mens Room (2nd Floor)");
            options.Add("MIP Lab");
            options.Add("QUEST Lab");
            options.Add("Stairs (2nd Floor)");
        }

        SearchableDropDown.ChangeOptions(options);
    }



    private Vector3[] AddLineOffset()
    {
        if (navigationYOffset.value == 0)
        {
            return path.corners;
        }

        Vector3[] calculatedLine = new Vector3[path.corners.Length];
        for (int i = 0; i < path.corners.Length; i++)
        {
            calculatedLine[i] = path.corners[i] + new Vector3(0, navigationYOffset.value, 0);
        }
        return calculatedLine;
    }
}
