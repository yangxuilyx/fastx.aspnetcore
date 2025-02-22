using FastXTpl.Template.Application.Identity.Ous.Dtos;
using FastXTpl.Template.Application.Identity.Users.Dtos;

namespace FastXTpl.Template.Application.Manage.Threes.Dtos;

/// <summary>
/// 三会一课
/// </summary>
public class ThreeDto
{
    /// <summary>
    /// 三会一课Id
    /// </summary>
    public string ThreeId { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    public DateTime StartTime { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    public DateTime EndTime { get; set; }

    /// <summary>
    /// 会议图片
    /// </summary>
    public string? Pic { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// 用户列表
    /// </summary>
    public List<UserDto> Users { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    public string? UserNames => Users?.Select(t => t.Name).JoinAsString(",");

    /// <summary>
    /// 组织列表
    /// </summary>
    public List<OuDto> Ous { get; set; }

    /// <summary>
    /// 组织
    /// </summary>
    public string? OuNames => Ous?.Select(t => t.Name).JoinAsString(",");
}