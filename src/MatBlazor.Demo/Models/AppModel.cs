using System;

namespace MatBlazor.Demo.Models;

public class AppModel
{
    private readonly object syncObj = new object();
    private int _userCount = 0;

    public event EventHandler<int> UserCountChanged;

    public int GetUserCount()
    {
        lock (syncObj)
        {
            return _userCount;
        }
    }


    public void AddUserCount(int value)
    {
        lock (syncObj)
        {
            _userCount += value;
            OnUserCountChanged(_userCount);
        }
    }

    protected virtual void OnUserCountChanged(int e)
    {
        UserCountChanged?.Invoke(this, e);
    }
}