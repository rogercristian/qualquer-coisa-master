using System;

public static class GameEvents
{
    public static event Action OnGetGun;
    public static void GetGun() => OnGetGun?.Invoke();

    public static event Action OnSetStop;
    public static void SetStop() => OnSetStop?.Invoke();

    public static event Action OnSetMove;
    public static void SetMove() => OnSetMove?.Invoke();
}
