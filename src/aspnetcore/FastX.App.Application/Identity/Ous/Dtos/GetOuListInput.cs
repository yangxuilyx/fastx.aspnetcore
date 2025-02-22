using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastX.App.Application.Identity.Ous.Dtos;

public class GetOuListInput : IPagedResultRequest
{
    /// <summary>
    /// 上级Id
    /// </summary>
    public string ParentId { get; set; }

    /// <summary>
    /// Page
    /// </summary>
    public PageInfo Page { get; set; }
}