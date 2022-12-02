using System;

public enum CreateLoginRepository
{
    Success,
    Exists,
    InvalidLogin,
}
public enum GetLoginResult
{
    Success,
    NotFound,
    InvalidPassword,
}
public enum GetInfoResult
{
    Success,
    NotFound,
}
public enum UpdateLoginResult
{
    Success,
    NotFound,
    InvalidLogin,
}
public enum DeleteLoginResult
{
    Success,
    NotFound,
}