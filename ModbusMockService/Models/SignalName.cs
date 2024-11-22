namespace ModbusMockService.Models
{
    public enum SignalName
    {
        LifeBit,
        UnloadPalletRequest,
        LoadPalletRequest,
        AllUnloadPalletDone,
        AllLoadPalletDone,
        RobotInOperatorArea,
        PermissionToEnterOperatorAreaRequest,
        PermissionToEnterOperatorAreaAllowed,
        PermissionToEnterSafetyAreaRequest,
        PermissionToEnterSafetyAreaAllowed,
        PermissionToEnterBendingAreaRequest,
        PermissionToEnterBendingAreaAllowed,
        RobotInSafetyArea,
        MirInBendingArea,
        BenderInAlarm,
        RobotInAlarm,
        RobotAlarmCode,
        RobotInStop,
        LayoutID,
        Spare
    }
}
