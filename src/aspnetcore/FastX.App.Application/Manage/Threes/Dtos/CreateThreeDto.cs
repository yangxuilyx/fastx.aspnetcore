using FastX.App.Application.Identity.Ous.Dtos;
using FastX.App.Application.Identity.Users.Dtos;

namespace FastX.App.Application.Manage.Threes.Dtos;

/// <summary>
/// 创建三会一课
/// </summary>
public class CreateThreeDto
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
    public List<string> Users { get; set; }

    /// <summary>
    /// 组织列表
    /// </summary>
    public List<string> Ous { get; set; }
}