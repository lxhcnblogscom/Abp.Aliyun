using System.Threading.Tasks;
using Shouldly;
using Xunit;
using EasyAbp.Abp.Aliyun.Sms.Model.Request;
using EasyAbp.Abp.Aliyun.Sms.Model.Response;

namespace EasyAbp.Abp.Aliyun.Sms.Tests.RequestTests
{
    public class SendSmsRequest_Tests : AbpAliyunSmsTestBase
    {
        [Fact]
        public async Task Should_Return_Code_OK()
        {
            // Arrange
            var request = new SendSmsRequest(AbpAliyunSmsTestsConsts.TargetPhoneNumber, 
                AbpAliyunSmsTestsConsts.CompanyName,
                AbpAliyunSmsTestsConsts.TemplateCode, 
                AbpAliyunSmsTestsConsts.TemplateParamJson);
            
            // Act
            var result = await AliyunApiRequester.SendRequestAsync<SendSmsResponse>(request,
                AbpAliyunSmsOptions.EndPoint);
            
            // Assert
            result.ShouldNotBeNull();
            result.Code.ShouldBe("OK");
        }
    }
}