using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class updateHealth : MonoBehaviour
{

    public TextMeshProUGUI valueTXT;

    public void UpdateTextValue(float _value, float _currentMaxHealthAmmo)
    {
        float PR = (_value*100)/_currentMaxHealthAmmo;
        PR = Mathf.Round(PR);
        valueTXT.text = _value.ToString();
        valueTXT.text += "%";

    }

}
