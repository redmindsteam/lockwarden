using System;

public enum CreateImageRepository
{
    Success,
    Exists,
    InvalidLogin,
}
public enum GetImageResult
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
public enum UpdateImageResult
{
    Success,
    NotFound,
    InvalidLogin,
}
public enum DeleteImageResult
{
    Success,
    NotFound,
}