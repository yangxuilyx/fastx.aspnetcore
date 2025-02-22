using System.ComponentModel;
using FastX.Data.DataFilters;
using FastX.Data.Entities;
using FastX.Data.SqlSugar.DataAnnotations;

namespace FastXTpl.Template.Core.Identity.Users;

/// <summary>
/// 用户
/// </summary>
[XSugarTable("Identity")]
public class User : Entity, ISoftDelete
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public Ulid UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// 身份证号
    /// </summary>
    public string? IdNo { get; set; }

    /// <summary>
    /// 党员类型   0: 群众 1: 正式党员 2: 预备党员 3: 发展对象 4: 入党积极分子
    /// </summary>
    public UserType UserType { get; set; }

    /// <summary>
    /// 组织Id
    /// </summary>
    public Ulid? OuId { get; set; }

    /// <summary>
    /// 职务
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// 职务
    /// </summary>
    public PositionType PositionType { get; set; }

    /// <summary>
    /// 是否超管
    /// </summary>
    public bool? IsSpecial { get; set; }

    /// <summary>
    /// IsDeleted
    /// </summary>
    public bool IsDeleted { get; set; }
}

public enum PositionType
{
    [Description("普通用户")]
    _0,

    [Description("部门领导")]
    _1,
}
