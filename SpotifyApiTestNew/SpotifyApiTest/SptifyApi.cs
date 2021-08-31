using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using SpotifyApiTest.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace SpotifyApiTest.SpotifyApiTest
{
    [TestClass]
    public class SptifyApi
    {
        private string playlistUrl = "https://api.spotify.com/v1/users/w8yzimnlx3v3sehszoipy1d8r/playlists";
        private string accessToken = "Bearer BQC8e6hq6Ci_cKEGqQRbm3CEZQfX9o1GhJiOLVnFxwHKFuZx-ExDYkpwySG9eBKpv_6bysMOv1SdeIC4NKMYR3E4X8-Z969DQQnh8LgGuQGLrv47or0QkuVL71HjnqmsSuXFaFCi9eB2yWHPE1sBPOxHHdIjmybaqZodAmxRpDO_zkTHyxRFWJVihqyA4O0BcMmWjU1ow76vADnJrw7WUVDeFNB2WlAusVp_GnhFj7oo";
        //private string accessToken = "test";
        private string playlistID;
        IRestClient restClient;

        [TestInitialize]
        public void start()
        {
            restClient = new RestClient(); // this is the client which sends the request , it is having postman setup
        }

        [TestMethod]
        public void createPlayList()
        {
            IRestRequest restRequest = new RestRequest(playlistUrl);
            string requestPayload = "{\r\n\"name\" : \"Ramesha test5 Playlist\"\r\n}";
            restRequest.AddJsonBody(requestPayload);
            restRequest.AddHeader("Authorization", accessToken);
            IRestResponse<DataDto> restResponse = restClient.Post<DataDto>(restRequest);
            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(201, (int)restResponse.StatusCode);
            Console.WriteLine($"Your playlist {restResponse.Data.name} is created successfully");
            playlistID = restResponse.Data.id;
            Assert.AreEqual("Ramesha test5 Playlist", restResponse.Data.name);
        }

        [TestMethod]
        public void getplaylist()
        {
            IRestRequest restRequest = new RestRequest($"{playlistUrl}/{playlistID}");
            restRequest.AddHeader("Authorization", accessToken);
            IRestResponse restResponse = restClient.Get(restRequest);
            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(200, (int)restResponse.StatusCode);

        }

    }
}
