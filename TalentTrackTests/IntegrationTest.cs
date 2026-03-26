using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TalentTrack.DTO;

namespace TalentTrackTests;

[TestClass]
public class IntegrationTest
{
    [TestMethod]
    public async Task GetCandidates_WithValidToken_ReturnsOk()
    {
        var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        // Step 1: login
        var login = new
        {
            username = "Yogi",
            password = "20002026!"
        };

        var loginResponse = await client.PostAsJsonAsync("/api/Auth/login", login);

        Assert.IsTrue(loginResponse.IsSuccessStatusCode);

        var loginResult = await loginResponse.Content.ReadFromJsonAsync<LoginResponse>();

        string token = loginResult!.Token;
        // Step 2: attach token
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        // Step 3: call protected API
        var response = await client.GetAsync("/api/v1/Candidate");

        // Step 4: verify
        Assert.IsTrue(response.IsSuccessStatusCode);
    }
}
