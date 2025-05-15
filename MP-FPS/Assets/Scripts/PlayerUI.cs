using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    RectTransform FuelFill;

    private PlayerController controller;

    public void SetController(PlayerController _controller)
    {
        controller = _controller;
    }

    void Update()
    {
        SetFuelAmt(controller.GetFuelAmt());
    }

    void SetFuelAmt (float amt)
    {
        FuelFill.localScale = new Vector3(1f, amt, 1f);
    }
    
}
