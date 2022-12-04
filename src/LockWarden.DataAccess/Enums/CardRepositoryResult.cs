using System;

public enum CreateCardRepository
{
    Success,
    Exists,
    InvalidLogin,
}
public enum GetCardResult
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
public enum UpdateCardResult
{
    Success,
    NotFound,
    InvalidLogin,
}
public enum DeleteCardResult
{
    Success,
    NotFound,
}