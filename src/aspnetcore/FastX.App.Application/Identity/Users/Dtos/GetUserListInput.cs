using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastX.App.Application.Identity.Users.Dtos;

/// <summary>
/// GetUserListInput
/// </summary>
public class GetUserListInput : IPagedResultRequest,ISortedResultRequest
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Page
    /// </summary>
    public PageInfo Page { get; set; }

    /// <summary>
    /// 分页
    /// </summary>
    public string? Sorting
    {
        get;
        set;
    } = "UserId DESC";
}