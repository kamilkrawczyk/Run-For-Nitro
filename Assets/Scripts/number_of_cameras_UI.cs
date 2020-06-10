using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class number_of_cameras_UI : MonoBehaviour
{
    public int number_of_cameras;
    private TextMeshProUGUI m_text;
    // Start is called before the first frame update
    void Start()
    {
        number_of_cameras = 2;
        m_text = GetComponent<TextMeshProUGUI>();
        m_text.text = "" + number_of_cameras;
    }
    public void AddCamera()
    {
        number_of_cameras++;
        m_text.text = "" + number_of_cameras;
    }
    public void CameraThrown()
    {
        number_of_cameras--;
        m_text.text = "" + number_of_cameras;
    }

    
}
