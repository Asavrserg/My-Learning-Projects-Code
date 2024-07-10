using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayBalance;

    [SerializeField] int startingBalance = 100;

    [SerializeField] int currentBalance;
    public int CurrentBalance
    {
        get
        {
            return currentBalance;
        }
    }


    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplayText();
    }


    private void UpdateDisplayText()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplayText();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplayText();

        if (currentBalance < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
