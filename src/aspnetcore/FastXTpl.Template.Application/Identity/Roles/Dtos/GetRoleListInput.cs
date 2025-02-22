using FastX.Application.Dtos;
using FastX.Data.PagedResult;

namespace FastXTpl.Template.Application.Identity.Roles.Dtos;

/// <summary>
/// GetRoleListInput
/// </summary>
public class GetRoleListInput : IPagedResultRequest
{
    /// <summary>
    /// Page
    /// </summary>
    public PageInfo Page { get; set; }
}