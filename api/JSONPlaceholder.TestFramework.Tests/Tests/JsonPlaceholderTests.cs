using System.Net;
using JSONPlaceholder.TestFramework.Business.Models;
using JSONPlaceholder.TestFramework.Business.Validations;
using RestSharp;

namespace JSONPlaceholder.TestFramework.Tests.Tests;

[Parallelizable(ParallelScope.All)]
public class JsonPlaceholderTests : BaseTest
{
    [Test, Category("API")]
    public async Task ValidateReceivingListOfUsers()
    {
        var actualResponse = await Client.GetUsersAsync();

        Assert.Multiple(() =>
        {
            Assert.That(actualResponse.IsSuccessful);
            Assert.That(actualResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That((bool)actualResponse.Data?.All(user =>
                user.IsHaveId()
                && user.IsNameNonEmpty()
                && user.IsUserNameNonEmpty()
                && user.IsHaveEmail()
                && user.IsHaveAddress()
                && user.IsHavePhone()
                && user.IsHaveWebsite()
                && user.IsHaveCompany()
            ));
        });
    }

    [Test, Category("API")]
    public async Task ValidateResponseContentTypeHeader()
    {
        var actualResponse = await Client.GetUsersAsync();

        Assert.Multiple(() =>
        {
            Assert.That(actualResponse.IsSuccessful);
            Assert.That(actualResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(actualResponse.GetContentHeaderValue("Content-Type"), Is.Not.Null);
            Assert.That(actualResponse.GetContentHeaderValue("Content-Type"), Is.EqualTo("application/json; charset=utf-8"));
        });
    }

    [Test, Category("API")]
    public async Task ValidateUserInListOfUsers()
    {
        var actualResponse = await Client.GetUsersAsync();

        Assert.Multiple(() =>
        {
            Assert.That(actualResponse.IsSuccessful);
            Assert.That(actualResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(actualResponse.Data?.Count, Is.EqualTo(10));
            Assert.That((bool)actualResponse.Data?.IsAllIdUniq());
            Assert.That((bool)actualResponse.Data?.All(user =>
                user.IsNameNonEmpty()
                && user.IsUserNameNonEmpty()
            ));
            Assert.That(actualResponse.Data.All(user => (bool)user.Company?.IsHaveName()));

        });
    }

    [Test, Category("API")]
    public async Task ValidateUserCreation()
    {
        var newUser = new UserBuilder
        {
            Name = "NewName",
            Username = "NewUserName"
        }.Build();

        var actualResponse = await Client.CreateUserAsync(newUser);

        Assert.Multiple(() =>
        {
            Assert.That(actualResponse.IsSuccessful);
            Assert.That(actualResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That((bool)actualResponse.Data?.IsHaveId());
        });
    }

    [Test, Category("API")]
    public async Task ValidateResourceNotExist()
    {
        var actualResponse = await Client.GetInvalidResource();

        Assert.Multiple(() =>
        {
            Assert.That(actualResponse.ResponseStatus, Is.EqualTo(ResponseStatus.Completed));
            Assert.That(actualResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        });
    }

}
