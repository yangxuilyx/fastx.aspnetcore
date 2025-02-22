using FastXTpl.Template.Host.Models.Sms;
using Microsoft.AspNetCore.Mvc;
using TencentCloud.Common;
using TencentCloud.Sms.V20210111;
using TencentCloud.Sms.V20210111.Models;

namespace FastXTpl.Template.Host.Controllers;

/// <summary>
/// Account
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class SmsController : ControllerBase
{
    private IConfiguration _configuration;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="configuration"></param>
    public SmsController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 获取短信验证码
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<SmsOutput> GetPhoneCode(GetPhoneCodeInput input)
    {
        var secretId = _configuration.GetValue<string>("Tencent:SecretId");
        var secretKey = _configuration.GetValue<string>("Tencent:SecretKey");

        Credential cred = new Credential
        {
            SecretId = secretId,
            SecretKey = secretKey
        };

        var code = GetRomNum();

        SmsClient client = new SmsClient(cred, "ap-guangzhou");

        /* 实例化一个请求对象，根据调用的接口和实际情况，可以进一步设置请求参数
                * 您可以直接查询SDK源码确定SendSmsRequest有哪些属性可以设置
                * 属性可能是基本类型，也可能引用了另一个数据结构
                * 推荐使用IDE进行开发，可以方便的跳转查阅各个接口和数据结构的文档说明 */
        SendSmsRequest req = new SendSmsRequest();


        /* 基本类型的设置:
         * SDK采用的是指针风格指定参数，即使对于基本类型您也需要用指针来对参数赋值。
         * SDK提供对基本类型的指针引用封装函数
         * 帮助链接：
         * 短信控制台: https://console.cloud.tencent.com/smsv2
         * 腾讯云短信小助手: https://cloud.tencent.com/document/product/382/3773#.E6.8A.80.E6.9C.AF.E4.BA.A4.E6.B5.81 */
        /* 短信应用ID: 短信SdkAppId在 [短信控制台] 添加应用后生成的实际SdkAppId，示例如1400006666 */
        // 应用 ID 可前往 [短信控制台](https://console.cloud.tencent.com/smsv2/app-manage) 查看
        req.SmsSdkAppId = "1400934685";

        /* 短信签名内容: 使用 UTF-8 编码，必须填写已审核通过的签名 */
        // 签名信息可前往 [国内短信](https://console.cloud.tencent.com/smsv2/csms-sign) 或 [国际/港澳台短信](https://console.cloud.tencent.com/smsv2/isms-sign) 的签名管理查看
        req.SignName = "贵州中诚网络";


        /* 模板 ID: 必须填写已审核通过的模板 ID */
        // 模板 ID 可前往 [国内短信](https://console.cloud.tencent.com/smsv2/csms-template) 或 [国际/港澳台短信](https://console.cloud.tencent.com/smsv2/isms-template) 的正文模板管理查看
        req.TemplateId = "2254303";


        /* 模板参数: 模板参数的个数需要与 TemplateId 对应模板的变量个数保持一致，若无模板参数，则设置为空 */
        req.TemplateParamSet = new String[] { code, "10" };


        /* 下发手机号码，采用 E.164 标准，+[国家或地区码][手机号]
         * 示例如：+8613711112222， 其中前面有一个+号 ，86为国家码，13711112222为手机号，最多不要超过200个手机号*/
        req.PhoneNumberSet = new String[] { input.PhoneNumber };


        SendSmsResponse resp = client.SendSmsSync(req);
        if (resp.SendStatusSet.FirstOrDefault()?.Code!= "Ok")
        {
            throw new Exception(resp.SendStatusSet.FirstOrDefault()?.Message);
        }
        return new SmsOutput()
        {
            Code = code
        };
    }

    private string GetRomNum()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 10) * 100000 + random.Next(0, 100000);
        return randomNumber.ToString("D6");
    }

}