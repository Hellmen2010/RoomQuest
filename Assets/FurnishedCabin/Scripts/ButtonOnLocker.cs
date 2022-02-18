using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonOnLocker : MonoBehaviour
{
    private Locker _locker;
    private Locker locker => _locker is null ? _locker = FindObjectOfType<Locker>() : _locker;

    private Button _button;
    private Button button => _button is null ? _button = GetComponent<Button>() : _button;

    public void OnButtonPressed() => locker.PlayerInput(button);
}
