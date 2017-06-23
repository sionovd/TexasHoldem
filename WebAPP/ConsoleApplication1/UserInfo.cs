using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class UserInfo
{
    private static readonly UserInfo USER = new UserInfo();
    private string username;
    private string email;
    private string password;
    private int moneyBalance;

    private UserInfo()
    {
        username = "";
        email = "";
        password = "";
        moneyBalance = -1;

    }
    public static UserInfo GetUser()
    {
        return USER;
    }
    public string GetUsername()
    {
        return username;
    }
    public string GetEmail()
    {
        return email;
    }

    public string GetPassword()
    {
        return password;
    }

    public int GetMoneyBalance()
    {
        return moneyBalance;
    }

    public void SetUserName(string username)
    {
        USER.username = username;
    }

    public void SetPassword(string password)
    {
        USER.password = password;
    }

    public void SetEmail(string email)
    {
        USER.email = email;
    }

    public void SetMoneyBalance(int moneyBalance)
    {
        USER.moneyBalance = moneyBalance;
    }

    public bool IsSet()
    {
        return (moneyBalance >= 0 && !email.Equals("") && !username.Equals("") && !password.Equals(""));

    }


}