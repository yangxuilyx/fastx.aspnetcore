using FastX.Authorization.Permissions.Abstractions;

namespace FastXTpl.Template.Application.Manage.Authorization;

public class ManagePermissionDefinitionProvider : PermissionDefinitionProvider
{
    /// <summary>
    /// Define
    /// </summary>
    /// <param name="context"></param>
    public override void Define(IPermissionDefinitionContext context)
    {
        var groupDefinition = context.AddGroup("Manage", "0000", "管理组");

        var notiPermission = groupDefinition.AddPermission("Noti","宣传管理");
        notiPermission.AddChild(Permissions.Noti0, "党建动态");
        notiPermission.AddChild(Permissions.Noti1, "组织活动");

        var study0 = groupDefinition.AddPermission("Study0", "学习平台");
        study0.AddChild(Permissions.Study, "在线学习");
        study0.AddChild(Permissions.Examine, "在线考核");
        study0.AddChild(Permissions.Question, "题库管理");

        var ex = groupDefinition.AddPermission("ex", "考核监督平台");
        ex.AddChild(Permissions.Integral, "积分记录");
        ex.AddChild(Permissions.Work, "工作任务");
        ex.AddChild(Permissions.Three, "三会一课");

        var manage = groupDefinition.AddPermission("manage", "党务管理平台");
        manage.AddChild(Permissions.Fee, "党费收缴");
        manage.AddChild(Permissions.User, "党员管理");
        manage.AddChild(Permissions.Ou, "组织管理");

        var identity = groupDefinition.AddPermission("identity", "系统管理");
        identity.AddChild(Permissions.Role, "角色管理");
    }
}