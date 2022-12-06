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
public enum GetInfoImageResult
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