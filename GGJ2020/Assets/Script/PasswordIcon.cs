using UnityEngine;
using System.Collections;

public class PasswordIcon : MonoBehaviour
{

    [SerializeField] private PasswordExe _exePrefab = null;

    public void OnClick()
    {
        PasswordExe instance = Instantiate(_exePrefab, transform.parent.parent);
    }

}
